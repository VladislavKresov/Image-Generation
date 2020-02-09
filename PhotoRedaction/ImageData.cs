using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoRedaction
{
    class ImageData
    {
        private string[] pathes;
        private List<int>[] frames;
        private int count;
        private int countCoordinates = 16;

        public ImageData(string[] lines)
        {
            count = lines.Length;
            pathes = new string[count];
            frames = new List<int>[count];
            for (int i = 0; i < count; i++)
            {
                string[] data = lines[i].Split(',');
                pathes[i] = data[0];

                List<int> coords = new List<int>();
                for (int j = 1; j < data.Length; j++)
                {
                    coords.Add(int.Parse(data[j])); 
                }
                if(coords.Count < countCoordinates)
                    for (int k = coords.Count; k < countCoordinates; k++)
                    {
                        coords.Add(0);
                    }
                frames[i] = coords;
            }
        }

        public string getPath(int indx)
        {
            return pathes[indx];
        }

        public List<int> getFrames(int indx)
        {
            return frames[indx];
        }

        public List<int>[] getAllFrames()
        {
            return frames;
        }

        public int getCountOfImages()
        {
            return count;
        }
    }
}
