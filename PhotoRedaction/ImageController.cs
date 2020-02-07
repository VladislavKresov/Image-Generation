using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoRedaction
{
    class ImageController
    {
        public static void drawFrame(Bitmap image, int x, int y, int with, int height)
        {
            Graphics g = Graphics.FromImage(image);
            g.DrawRectangle(new Pen(Color.Red, 10f), x,y,with,height);
            g.DrawImage(image, 0, 0, image.Width, image.Height);
        }
                      
        public static void drawFrames(Bitmap image, Rectangle[] rectangles)
        {
            Graphics g = Graphics.FromImage(image);
            g.DrawRectangles(new Pen(Color.Red, 10f), rectangles);
            g.DrawImage(image, 0, 0, image.Width, image.Height);
        }
                      
        public static void grey(Bitmap image)
        {
            ColorMatrix cm = new ColorMatrix();
            cm.Matrix00 = cm.Matrix01 = cm.Matrix02 =
            cm.Matrix10 = cm.Matrix11 = cm.Matrix12 =
            cm.Matrix20 = cm.Matrix21 = cm.Matrix22 = 0.34f;
            colorCorrection(image, cm);
        }
                      
        public static void lighten(Bitmap image)
        {
            float[][] colorMatrixElements = {
               new float[] {1,  0,  0,  0, 0},        // red
               new float[] {0,  1,  0,  0, 0},        // green
               new float[] {0,  0,  1,  0, 0},        // blue
               new float[] {0,  0,  0,  1, 0},        // alpha
               new float[] {0.15f, 0.15f, 0.15f, 0, 1}};//translations

            ColorMatrix cm = new ColorMatrix(colorMatrixElements);
            colorCorrection(image, cm);
        }

        public static void darken(Bitmap image)
        {
            ColorMatrix cm = new ColorMatrix();
            cm.Matrix00 = cm.Matrix11 = cm.Matrix22 = 0;
            cm.Matrix33 = 0.3f;
            colorCorrection(image, cm);
        }

        public static void blur(Bitmap image)
        {
            
        }
                      
        public static void glare(Bitmap image)
        {
            
        }
                      
        public static void rotate_90(Bitmap image)
        {
            image.RotateFlip(RotateFlipType.Rotate90FlipX);
        }
                      
        public static void shift(Bitmap image)
        {
            
        }
                      
        public static void stretch(Bitmap image)
        {
            
        }

        private static void colorCorrection(Bitmap image, ColorMatrix cm)
        {
            ImageAttributes ia = new ImageAttributes();
            ia.SetColorMatrix(cm);
            Graphics g = Graphics.FromImage(image);
            g.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, ia);
            g.Dispose();
        }

        
    }
}
