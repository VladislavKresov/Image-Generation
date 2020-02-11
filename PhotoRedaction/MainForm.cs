using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoRedaction
{
    public partial class MainForm : Form
    {
        private bool showFrames;
        private int pictLeftX;
        private int pictLeftY;
        private int pictRightX;
        private int pictRightY;
        private int countPictures = 0;
        private int currentNumber;
        private MainFile mainFile;
        private byte[] currentImage;
        private byte[] currentRedactedImage;
        private ImageData imageData;
        private TargetData targetData;
        private string currentPath;
        private List<int> currentFrames;
        private List<int> changes;
        private string[] lines;

        public MainForm()
        {
            InitializeComponent();
            pullSaves();
            init();
        }

        private void pullSaves()
        {
            try
            {
                string lastPath = MainFile.pullSavesLine();
                mainFile = new MainFile(lastPath);
            }
            catch
            {
                mainFile = new MainFile(String.Empty);
                BTN_Prev.Enabled = false;
                BTN_Next.Enabled = false;
                BTN_SaveAll.Enabled = false;
            }
        }

        private void init()
        {
            if (pathExists(mainFile.getPath()))
            {
                try
                {
                    initVariables();
                    initViews();
                    update();
                }
                catch
                {
                    MessageBox.Show("File damaged: " + currentPath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    mainFile.clearSaves();
                    pullSaves();
                }
            }
            else
            {
                comboBoxMode.Enabled = false;
                BTN_Prev.Enabled = false;
                BTN_Next.Enabled = false;
                BTN_SaveAll.Enabled = false;
                pictureBoxLeft.Visible = false;
                pictureBoxRight.Visible = false;
            }
        }

        private void initVariables()
        {
            currentNumber = 0;
            showFrames = checkBoxFrames.Checked;
            lines = mainFile.getAllLines().ToArray();
            imageData = new ImageData(lines);
            targetData = new TargetData(imageData.getAllFrames(), imageData.getPathes());
            countPictures = imageData.getCountOfImages();
            pictLeftX = panelLeft.Width;
            pictLeftY = panelLeft.Height;
            pictRightX = panelRight.Width;
            pictRightY = panelRight.Height;
            changes = new List<int>();
            checkBoxFrames.Checked = true;
        }

        private void initViews()
        {          
            pictureBoxLeft.Size = new Size(pictLeftX, pictLeftY);
            pictureBoxRight.Size = new Size(pictRightX, pictRightY);
            comboBoxMode.Enabled = true;
            BTN_Prev.Enabled = true;
            BTN_Next.Enabled = true;
            BTN_SaveAll.Enabled = true;
            pictureBoxLeft.Visible = true;
            pictureBoxRight.Visible = true;
        }

        private void update()
        {
            try
            {
                parseCurrent();
                currentRedactedImage = redactImage(currentRedactedImage, changes, currentNumber);
                currentFrames = targetData.getFrames(currentNumber);
                currentRedactedImage = drawFrames(currentRedactedImage, currentFrames, showFrames);
                showImages();
                labelPath.Text = currentPath;
            }
            catch(FileNotFoundException)
            {
                MessageBox.Show("File not found: " + currentPath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void parseCurrent()
        {
            try
            {
                targetData.setFrames(imageData.getAllFrames());
                currentPath = imageData.getPath(currentNumber);
                using(Bitmap bitmap = new Bitmap(currentPath))
                    currentImage = bitmapToByte(bitmap);
                currentRedactedImage = currentImage;                
                currentFrames = targetData.getFrames(currentNumber);                
            }
            catch
            {
                throw new FileNotFoundException();
                
            }
        }

        private byte[] redactImage(byte[] image, List<int> redactionTypes, int currentNumber)
        {
            for (int i = 0; i < redactionTypes.Count; i++)
            {
                switch (redactionTypes[i])
                {
                    case 0://clear effects
                        changes.Clear();
                        image = currentImage;
                        BTN_Cancel.Enabled = false;
                        break;
                    case 1://Lightening
                        image = ImageController.brightness(image,25);
                        break;
                    case 2://shadowing
                        image = ImageController.shadowing(image,5);
                        break;                    
                    case 3://crop
                        int width, height;
                        using(Bitmap img = byteToBitmap(image))
                        {
                            width = img.Width;
                            height = img.Height;
                        }
                        if(width>=height)
                            image = cropToSquare(image, currentNumber);
                        else
                        {
                            rotateFrames_90_Left(currentNumber, image);
                            image = ImageController.rotate(image, -90f);

                            image = cropToSquare(image,currentNumber);

                            rotateFrames_90_Right(currentNumber, image);
                            image = ImageController.rotate(image, 90f);
                        }
                        break;
                    case 4://rotate 90 left
                        rotateFrames_90_Left(currentNumber, image);
                        image = ImageController.rotate(image, -90f);
                        break;
                    case 5://pixelize
                        image = ImageController.quality(image,25);
                        break;
                    default:
                        break;
                }
            }
            return image;
        }

        private byte[] drawFrames(byte[] image,List<int>frames,bool show)
        {
            if (show)
            {
                Rectangle[] rects = new Rectangle[4];
                int currentX = 0;                
                for (int countFrames = 0; countFrames < rects.Length; countFrames++)
                {
                    int with = Math.Abs(frames[currentX + 2] - frames[currentX]);
                    int height = Math.Abs(frames[currentX + 3] - frames[currentX + 1]);
                    rects[countFrames] = new Rectangle(frames[currentX], frames[currentX + 1], with, height);
                    currentX += 4;
                }
                return ImageController.drawFrames(image, rects);
            }
            else
                return image;
        }

        private void showImages()
        {
            try
            {
                pictureBoxLeft.Image = byteToBitmap(currentImage);
                pictureBoxRight.Image = byteToBitmap(currentRedactedImage);
            }
            catch
            {
                throw new FileNotFoundException();
            }
        }

        private async void saveAllPictures()
        {
            if (pathExists(mainFile.getPath()))
            {
                BTN_SaveAll.Text = "Saving...";
                enableViews(false);
                targetData.setFrames(imageData.getAllFrames());
                
                await Task.Run(() =>
                {
                    setLastLinePositionInFile(mainFile.getPath());
                    string pathToSave = mainFile.getPath();
                    string directory = getDirectoryToSave(pathToSave);
                    using (StreamWriter stream = new StreamWriter(pathToSave, true))
                    {
                        stream.WriteLine(String.Empty);
                        for (int currentImageNumber = 0; currentImageNumber < imageData.getCountOfImages(); currentImageNumber++)
                        {
                            if (pathExists(imageData.getPath(currentImageNumber)))
                            {                                
                                byte[] curImg = bitmapToByte(new Bitmap(imageData.getPath(currentImageNumber)));
                                curImg = redactImage(curImg, changes, currentImageNumber);
                                List<int> curCoords = targetData.getFrames(currentImageNumber);
                                string framesCoordsString = parseCoordinatesToString(curCoords);
                                string imgPath = createImagePath(directory);
                                using (MemoryStream ms = new MemoryStream(curImg))
                                {
                                    new Bitmap(ms).Save(imgPath);
                                }
                                stream.WriteLine(imgPath + framesCoordsString);                                
                            }
                        }
                    }
                });

                changes.Clear();
                BTN_SaveAll.Text = "Create all";
                BTN_Cancel.Enabled = false;
                enableViews(true);
                mainFile = new MainFile(mainFile.getPath());
                init();
            }
            else
            {
                MessageBox.Show("File unaviable: " + currentPath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private byte[] cropToSquare(byte[] image, int currentNumber)
        {
            int width;
            int height;
            using (Bitmap img = byteToBitmap(image))
            {
               width = img.Width;
               height = img.Height;
            }            
            List<int> frames = new List<int>(targetData.getFrames(currentNumber));
            int x = width - height;
            int y = 0;

            int minFrameCoordinateX = width;
            int maxFrameCoordinateX = 0;
            for (int currentLeftSideX = 0; currentLeftSideX < frames.Count; currentLeftSideX += 4)
            {
                if (frames[currentLeftSideX] < minFrameCoordinateX && frames[currentLeftSideX]!= frames[currentLeftSideX+2])
                    minFrameCoordinateX = frames[currentLeftSideX];
                if (frames[currentLeftSideX+2] > maxFrameCoordinateX)
                    maxFrameCoordinateX = frames[currentLeftSideX+2];
            }

            if (minFrameCoordinateX < x)
            {
                x = 0;
                int rightBorder = x + height;
                if (maxFrameCoordinateX > rightBorder)
                    for (int currentSideX = 0; currentSideX < frames.Count; currentSideX += 2)
                    {
                        if (frames[currentSideX] > rightBorder)
                            frames[currentSideX] = rightBorder;
                    }
            }
            else
            {
                for (int currentSideX = 0; currentSideX < frames.Count; currentSideX += 2)
                {
                    if (frames[currentSideX] >= x)
                        frames[currentSideX] -= x;
                    else
                        frames[currentSideX] = 0;
                }
            }

            targetData.setFrames(frames,currentNumber);
            image = ImageController.crop(image, x, y, height, height);
            return image;
        }

        private void rotateFrames_90_Left(int currentNumber, byte[] image)
        {
            List<int> frames = new List<int>(targetData.getFrames(currentNumber));
            List<int> newFrames = new List<int>();
            int width;
            int height;
            using (Bitmap img = byteToBitmap(image))
            {
                width = img.Width;
                height= img.Height;
            }
            for (int currentCoordinate = 0; currentCoordinate < frames.Count; currentCoordinate+=2)
            {
                int newX = frames[currentCoordinate+1];
                int newY = width - frames[currentCoordinate];
                newFrames.Add(newX);
                newFrames.Add(newY);
            }

            for (int currentFrameY = 1; currentFrameY < newFrames.Count; currentFrameY += 4)
            {
                int rem = newFrames[currentFrameY];
                newFrames[currentFrameY] = newFrames[currentFrameY + 2];
                newFrames[currentFrameY + 2] = rem;
            }

            targetData.setFrames(newFrames, currentNumber);
        }

        private void rotateFrames_90_Right(int currentNumber, byte[] image)
        {
            List<int> frames = new List<int>(targetData.getFrames(currentNumber));
            List<int> newFrames = new List<int>();
            int width;
            int height;
            using (Bitmap img = byteToBitmap(image))
            {
                width = img.Width;
                height = img.Height;
            }
            for (int currentCoordinate = 0; currentCoordinate < frames.Count; currentCoordinate += 2)
            {
                int newX = height - frames[currentCoordinate + 1];
                int newY = frames[currentCoordinate];
                newFrames.Add(newX);
                newFrames.Add(newY);
            }

            for (int currentFrameX = 0; currentFrameX < newFrames.Count; currentFrameX += 4)
            {
                int rem = newFrames[currentFrameX];
                newFrames[currentFrameX] = newFrames[currentFrameX + 2];
                newFrames[currentFrameX + 2] = rem;
            }

            targetData.setFrames(newFrames, currentNumber);
        }

        private void setLastLinePositionInFile(string path)
        {
            using (FileStream fileStream = new FileStream(path, FileMode.Open))            
                fileStream.Seek(0, SeekOrigin.End);                          
        }

        private byte[] bitmapToByte(Bitmap img)
        {
            ImageConverter converter = new ImageConverter();
            byte[] newImg = (byte[])converter.ConvertTo(img, typeof(byte[]));
            img.Dispose();
            return newImg;
        }

        private Bitmap byteToBitmap(byte[] img)
        {
            Bitmap image;
            using (MemoryStream ms = new MemoryStream(img))
                image = new Bitmap(ms);
            return image;
        }

        private bool pathExists(string path)
        {
            return File.Exists(path);
        }

        private string getDirectoryToSave(string path)
        {
            return Path.GetDirectoryName(path);
        }

        private void enableViews(bool enable)
        {
            panelFormBackground.Enabled = enable;
        }

        private string parseCoordinatesToString(List<int> coords)
        {
            string coordinates = "";
            for (int k = 0; k < coords.Count; k++)
            {
                coordinates += "," + coords[k];
            }
            return coordinates;
        }

        private string createImagePath(string directory)
        {
            int k = imageData.getCountOfImages()+1;
            string path = directory + @"\" + k + ".jpg";
            while (File.Exists(path))
            {
                k++;
                path = directory + @"\" + k + ".jpg";
            }
            return path;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (mainFile != null)
                mainFile.pushSavesLine();
        }

        private void BTN_Prew_Click(object sender, EventArgs e)
        {
            if (currentNumber > 0)
            {
                currentNumber--;               
            }
            else
            {
                currentNumber = countPictures - 1;
            }
            update();
        }

        private void BTN_Next_Click(object sender, EventArgs e)
        {
            if (currentNumber < countPictures - 1)
            {
                currentNumber++;         
            }
            else
            {
                currentNumber = 0;
            }
            update();
        }

        private void trackBarLeft_Scroll(object sender, EventArgs e)
        {
            pictLeftX = (int)(panelLeft.Width * (1f + 0.1 * trackBarLeft.Value));
            pictLeftY = (int)(panelLeft.Height * (1f + 0.1 * trackBarLeft.Value));
            pictureBoxLeft.Size = new Size(pictLeftX, pictLeftY);
        }

        private void trackBarRight_Scroll(object sender, EventArgs e)
        {
            pictRightX = (int)(panelRight.Width * (1f + 0.1 * trackBarRight.Value));
            pictRightY = (int)(panelRight.Height * (1f + 0.1 * trackBarRight.Value));
            pictureBoxRight.Size = new Size(pictRightX, pictRightY);
        }

        private void checkBoxFrames_CheckedChanged(object sender, EventArgs e)
        {
            showFrames = checkBoxFrames.Checked;
            update();
        }

        private void comboBoxMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            BTN_Apply.Enabled = true;
            update();
        }

        private void BTN_Apply_Click(object sender, EventArgs e)
        {
            changes.Add(comboBoxMode.SelectedIndex);
            BTN_Cancel.Enabled = true;
            update();
        }

        private void BTN_Cancel_Click(object sender, EventArgs e)
        {
            changes.RemoveAt(changes.Count - 1);
            if (changes.Count == 0)
                BTN_Cancel.Enabled = false;
            update();
        }

        private void BTN_SaveAll_Click(object sender, EventArgs e)
        {
            saveAllPictures();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string path = ofd.FileName;
                try
                {
                    mainFile = new MainFile(path);
                    init();
                }
                catch
                {
                    MessageBox.Show("File unaviable", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void panelRight_SizeChanged(object sender, EventArgs e)
        {
            if(pictRightX<panelRight.Width)
                pictRightX = panelRight.Width;
            if(pictRightY<panelRight.Height)
                pictRightY = panelRight.Height;
            pictureBoxRight.Size = new Size(pictRightX, pictRightY);
        }

        private void panelLeft_SizeChanged(object sender, EventArgs e)
        {
            if(pictLeftX<panelLeft.Width)
                pictLeftX = panelLeft.Width;
            if(pictLeftY<panelLeft.Height)
                pictLeftY = panelLeft.Height;      
            pictureBoxLeft.Size = new Size(pictLeftX, pictLeftY);
        }
    }
}
