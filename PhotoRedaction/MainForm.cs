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
        private int pictDefaultX;
        private int pictDefaultY;
        private int countPictures = 0;
        private int currentNumber;
        private MainFile mainFile;
        private Bitmap currentImage;
        private Bitmap currentRedactedImage;
        private ImageData imageData;
        private string currentPath;
        private string writedFilePath;
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
                string[] lastSaves = MainFile.pullSavesLine().Split(',');
                mainFile = new MainFile(lastSaves[0]);
                currentNumber = 0; //int.Parse(lastSaves[1]);
                writedFilePath = lastSaves[2];
            }
            catch
            {
                currentNumber = 0;
                mainFile = new MainFile(String.Empty);
                writedFilePath = String.Empty;
            }
        }

        private void init()
        {
            if (File.Exists(mainFile.getPath()))
            {
                showFrames = checkBoxFrames.Checked;
                TB_PathToFile.Text = mainFile.getPath();
                if (!writedFilePath.Equals(String.Empty))
                    TB_PathToSave.Text = writedFilePath;
                lines = mainFile.getAllLines();
                imageData = new ImageData(lines);
                countPictures = imageData.getCount();
                pictDefaultX = pictureBoxLeft.Width;
                pictDefaultY = pictureBoxLeft.Height;
                comboBoxMode.Enabled = true;
                changes = new List<int>();
                update();
            }
        }

        private void update()
        {
            if (countPictures > 0 && countPictures > currentNumber)
            {
                parseCurrent();
                redactCurrentImage();
                showImages();
                labelPath.Text = currentPath;
            }
        }

        private void drawFrames()
        {
            Rectangle[] rects = new Rectangle[4];
            int j = 0;
            for (int i = 0; i < rects.Length; i++)
            {
                int with = currentFrames[j + 2] - currentFrames[j];
                int height = currentFrames[j + 3] - currentFrames[j+1];
                rects[i] = new Rectangle(currentFrames[j], currentFrames[j+1], with, height);
                j += 4;
            }
            ImageController.drawFrames(currentRedactedImage, rects);
        }

        private void redactCurrentImage()
        {
            for (int i = 0; i < changes.Count; i++)
            {
                switch (changes.ElementAt(i))
                {
                    case 0://без эффектов
                        changes.Clear();
                        BTN_Cancel.Enabled = false;
                        update();
                        break;
                    case 1://Размытие
                        ImageController.blur(currentRedactedImage);
                        break;
                    case 2://Осветление
                        ImageController.lighten(currentRedactedImage);
                        break;
                    case 3://Затемнение
                        ImageController.darken(currentRedactedImage);
                        break;
                    case 4://оттенки серого
                        ImageController.grey(currentRedactedImage);
                        break;
                    case 5://Блики
                        ImageController.glare(currentRedactedImage);
                        break;
                    case 6://Поворот на 90
                        ImageController.rotate_90(currentRedactedImage);
                        currentFrames = rotateFrame_90(currentFrames);
                        break;
                    case 7://Растяжение
                        ImageController.stretch(currentRedactedImage);
                        break;
                    case 8://Сдвиг
                        ImageController.shift(currentRedactedImage);
                        break;
                    default:
                        break;
                }
            }

            if (showFrames)
                drawFrames();
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
            BTN_SaveAll.Text = "Сохранение...";
            panelFormBackground.Enabled = false;
            await Task.Run(() =>
            {
                string pathToSave = TB_PathToSave.Text;
                string directory, fileName;
                if (File.Exists(pathToSave))
                {
                    directory = Path.GetDirectoryName(pathToSave);
                    fileName = Path.GetFileName(pathToSave);
                }
                else
                {
                    directory = Directory.CreateDirectory(Path.GetDirectoryName(mainFile.getPath())).FullName;
                    fileName = @"new data.txt";
                }
                using (StreamWriter stream = new StreamWriter(directory + @"\" + fileName, true))
                {
                    for (int i = 0; i < imageData.getCount(); i++)
                    {
                        Bitmap curImg = new Bitmap(imageData.getPath(i));
                        List<int> curCoords = imageData.getFrames(i);

                        for (int j = 0; j < changes.Count; j++)
                        {
                            switch (changes[j])
                            {
                                case 0://без эффектов
                                    changes.Clear();
                                    break;
                                case 1://Размытие
                                    ImageController.blur(curImg);
                                    break;
                                case 2://Осветление
                                    ImageController.lighten(curImg);
                                    break;
                                case 3://Затемнение
                                    ImageController.darken(curImg);
                                    break;
                                case 4://оттенки серого
                                    ImageController.grey(curImg);
                                    break;
                                case 5://Блики
                                    ImageController.glare(curImg);
                                    break;
                                case 6://Поворот на 90
                                    ImageController.rotate_90(curImg);
                                    curCoords = rotateFrame_90(curCoords);
                                    break;
                                case 7://Растяжение
                                    ImageController.stretch(curImg);
                                    break;
                                case 8://Сдвиг
                                    ImageController.shift(curImg);
                                    break;
                                default:
                                    break;
                            }
                        }

                        string coordinates = "";
                        for (int k = 0; k < curCoords.Count; k++)
                        {
                            coordinates += "," + curCoords[k];
                        }

                        string imgPath = directory + @"\mod" + i + ".jpg";
                        if (File.Exists(imgPath))
                            imgPath = directory+ @"\" + Path.GetFileNameWithoutExtension(imgPath) + "_" + i + ".jpg";
                        curImg.Save(imgPath);
                        stream.WriteLine(imgPath+coordinates);

                    }
                }
            });

            BTN_SaveAll.Text = "Сохранить все";
            panelFormBackground.Enabled = true;
        }

        private void BTN_SaveFile_Click(object sender, EventArgs e)
        {
            string path = TB_PathToFile.Text;

            if (!File.Exists(path))
                MessageBox.Show("Неверно указан путь к файлу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                mainFile = new MainFile(path);
                init();
            }
        }

        private void BTN_ChooseFile_Click(object sender, EventArgs e)
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

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (mainFile != null)
                mainFile.pushSavesLine(currentNumber, writedFilePath);
        }

        private void BTN_Prew_Click(object sender, EventArgs e)
        {
            if (currentNumber > 0)
            {
                currentNumber--;
                BTN_Next.Enabled = true;

                if (currentNumber == 0)
                    BTN_Prew.Enabled = false;

                update();
            }
            else
            {
                BTN_Prew.Enabled = false;
            }
        }

        private void BTN_Next_Click(object sender, EventArgs e)
        {
            if (currentNumber < countPictures - 1)
            {
                currentNumber++;
                BTN_Prew.Enabled = true;

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
            int with = (int)(pictDefaultX * (1f + 0.1 * trackBarLeft.Value));
            int height = (int)(pictDefaultY * (1f + 0.1 * trackBarLeft.Value));
            pictureBoxLeft.Size = new Size(with, height);
        }

        private void trackBarRight_Scroll(object sender, EventArgs e)
        {
            int with = (int)(pictDefaultX * (1f + 0.1 * trackBarRight.Value));
            int height = (int)(pictDefaultY * (1f + 0.1 * trackBarRight.Value));
            pictureBoxRight.Size = new Size(with, height);
        }

        private void BTN_SavePathToOut_Click(object sender, EventArgs e)
        {
            string path = TB_PathToSave.Text;

            if (!File.Exists(path))
                MessageBox.Show("Неверно указан путь к файлу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                writedFilePath = path;
                init();
            }
        }

        private void BTN_ChooseOut_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string path = ofd.FileName;
                if(File.Exists(path))
                {
                    writedFilePath = path;
                    init();
                }
                else
                {
                    MessageBox.Show("Невозможно открыть выбранный файл", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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

    }
}
