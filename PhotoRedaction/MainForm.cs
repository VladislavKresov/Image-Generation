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
        private Bitmap currentImage;
        private Bitmap currentRedactedImage;
        private ImageData imageData;
        private string currentPath;
        private List<int> currentFrames;
        private List<int> changes;
        private string[] lines;

        public MainForm()
        {
            InitializeComponent();
            pullSaves();
            init();
            checkBoxFrames.Checked = true;
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
                initVariables();
                initViews();
                update();
            }
        }

        private void initVariables()
        {
            currentNumber = 0;
            showFrames = checkBoxFrames.Checked;
            lines = mainFile.getAllLines().ToArray();
            imageData = new ImageData(lines);
            countPictures = imageData.getCountOfImages();
            pictLeftX = panelLeft.Width;
            pictLeftY = panelLeft.Height;
            pictRightX = panelRight.Width;
            pictRightY = panelRight.Height;
            changes = new List<int>();
        }

        private void initViews()
        {
            pictureBoxLeft.Size = new Size(pictLeftX, pictLeftY);
            pictureBoxRight.Size = new Size(pictRightX, pictRightY);
            comboBoxMode.Enabled = true;
            BTN_Prev.Enabled = true;
            BTN_Next.Enabled = true;
            BTN_SaveAll.Enabled = true;
        }

        private void update()
        {
            if (countPictures > currentNumber)
            {
                parseCurrent();
                currentFrames = redactImageAndFrames(currentRedactedImage,changes,currentFrames);
                drawFrames(showFrames);
                showImages();
                labelPath.Text = currentPath;
            }
        }

        private void drawFrames(bool show)
        {
            if (show)
            {
                Rectangle[] rects = new Rectangle[4];
                int j = 0;
                for (int i = 0; i < rects.Length; i++)
                {
                    int with = currentFrames[j + 2] - currentFrames[j];
                    int height = currentFrames[j + 3] - currentFrames[j + 1];
                    rects[i] = new Rectangle(currentFrames[j], currentFrames[j + 1], with, height);
                    j += 4;
                }
                ImageController.drawFrames(currentRedactedImage, rects);
            }
        }

        private List<int> redactImageAndFrames(Bitmap img, List<int> redactionTypes, List<int> frames)
        {
            for (int i = 0; i < redactionTypes.Count; i++)
            {
                switch (redactionTypes[i])
                {
                    case 0://без эффектов
                        changes.Clear();
                        BTN_Cancel.Enabled = false;
                        update();
                        break;
                    case 1://Размытие
                        ImageController.blur(img);
                        break;
                    case 2://Осветление
                        ImageController.lighten(img);
                        break;
                    case 3://Затемнение
                        ImageController.darken(img);
                        break;
                    case 4://оттенки серого
                        ImageController.gray(img);
                        break;
                    case 5://Блики
                        ImageController.glare(img);
                        break;
                    case 6://Поворот на 90
                        ImageController.rotate_90(img);
                        frames = rotateFrame_90(frames);
                        break;
                    case 7://Растяжение
                        ImageController.stretch(img);
                        break;
                    case 8://Сдвиг
                        ImageController.shift(img);
                        break;
                    default:
                        break;
                }
            }
            return frames;
        }

        private List<int> rotateFrame_90(List<int> coords)
        {
            List<int> newFrames = new List<int>();
            for (int i = 0; i < coords.Count; i+=2)
            {
                newFrames.Add(coords[i+1]);
                newFrames.Add(coords[i]);
            }
            return newFrames;
        }

        private void showImages()
        {
            try
            {
                pictureBoxLeft.Image = currentImage;
                pictureBoxRight.Image = currentRedactedImage;
            }
            catch
            {
                MessageBox.Show("Невозможно открыть файл: " + currentPath, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void parseCurrent()
        {
            try
            {
                currentPath = imageData.getPath(currentNumber);
                currentImage = new Bitmap(currentPath);
                currentRedactedImage = new Bitmap(currentPath);
                currentFrames = imageData.getFrames(currentNumber);
            }
            catch
            {
                MessageBox.Show("изображение не найдено: " + currentPath, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void saveAllPictures()
        {
            if (pathExists(mainFile.getPath()))
            {
                BTN_SaveAll.Text = "Saving...";
                enableViews(false);

                await Task.Run(() =>
                {
                    string pathToSave = mainFile.getPath();
                    string directory = getDirectoryToSave(pathToSave);
                    using (StreamWriter stream = new StreamWriter(pathToSave, true))
                    {
                        stream.WriteLine("");
                        for (int i = 0; i < imageData.getCountOfImages(); i++)
                        {
                            if (pathExists(imageData.getPath(i)))
                            {
                                Bitmap curImg = new Bitmap(imageData.getPath(i));
                                List<int> curCoords = imageData.getFrames(i);
                                curCoords = redactImageAndFrames(curImg, changes, curCoords);
                                string framesCoords = parseCoordinatesToString(curCoords);
                                string imgPath = createImagePath(directory);
                                curImg.Save(imgPath);
                                stream.WriteLine(imgPath + framesCoords);
                            }
                        }
                    }
                });

                changes.Clear();
                BTN_SaveAll.Text = "Create all";
                enableViews(true);
            }
            else
            {
                MessageBox.Show("Не указан файл разметки: " + currentPath, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            if (enable)
                panelFormBackground.Enabled = true;
            else
                panelFormBackground.Enabled = false;
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
            int k = 1;
            string path = directory + @"\mod" + k + ".jpg";
            while (File.Exists(path))
            {
                path = directory + @"\" + Path.GetFileNameWithoutExtension(path) + "_" + k + ".jpg";
                k++;
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
                BTN_Next.Enabled = true;

                if (currentNumber == 0)
                    BTN_Prev.Enabled = false;

                update();
            }
            else
            {
                BTN_Prev.Enabled = false;
            }
        }

        private void BTN_Next_Click(object sender, EventArgs e)
        {
            if (currentNumber < countPictures - 1)
            {
                currentNumber++;
                BTN_Prev.Enabled = true;

                if (currentNumber == countPictures - 1)
                    BTN_Next.Enabled = false;

                update();
            }
            else
            {
                BTN_Next.Enabled = false;
            }
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
                    MessageBox.Show("Невозможно открыть выбранный файл", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
