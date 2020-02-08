using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoRedaction
{
    class MainFile
    {
        private static string SAVEFILE_PATH = Directory.GetCurrentDirectory() + @"\save.txt";
        private string PATH;

        public MainFile(string Path)
        {
            this.PATH = Path;
        }

        public string readLine(int number)
        {
            string line = "";

            StreamReader file = new StreamReader(PATH);

            if (number > 0)
                for (int i = 0; i < number; i++)
                {
                    line = file.ReadLine();
                }

            file.Close();

            return line;
        }

        public string[] parseLine(string line)
        {
            string[] parsedData = new string[17];
            string[] data = line.Split(',');

            if (data.Length > parsedData.Length)
                throw new IndexOutOfRangeException();

            data.CopyTo(parsedData, 0);
            if (data.Length < parsedData.Length)
                for (int i = data.Length; i < parsedData.Length; i++)
                {
                    parsedData[i] = "0";
                }
            return parsedData;
        }

        public void pushSavesLine(int line, string pathToWrite)
        {
            using (StreamWriter stream = new StreamWriter(SAVEFILE_PATH))
                stream.Write(PATH + "," + line + "," + pathToWrite);
        }

        public static string pullSavesLine()
        {
            if (File.Exists(SAVEFILE_PATH))
            {
                using (StreamReader stream = new StreamReader(SAVEFILE_PATH))
                    return stream.ReadLine();
            }
            else
            {
                throw new Exception();
            }
        }

        public int getCountLines()
        {
            int count = 0;
            if (File.Exists(PATH))
                using (StreamReader sr = new StreamReader(PATH))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        count++;
                    }
                }
            return count;
        }

        public List<string> getAllLines()
        {
            List<string> lines = new List<string>(getCountLines());

            using (StreamReader sr = new StreamReader(PATH))
            {
                for (int i = 0; i < getCountLines(); i++)
                {
                    string currentLine = sr.ReadLine();
                    if(currentLine.Length>0)
                        lines.Add(currentLine);
                }
            }

            return lines;
        }

        public string getPath()
        {
            return PATH;
        }


    }
}
