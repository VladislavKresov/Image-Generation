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

        public void pushSavesLine()
        {
            using (StreamWriter stream = new StreamWriter(SAVEFILE_PATH,false))
                stream.Write(PATH);
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

        public List<string> getAllLines()
        {
            List<string> lines = new List<string>(getCountLines());

            if(File.Exists(PATH))
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

    }
}
