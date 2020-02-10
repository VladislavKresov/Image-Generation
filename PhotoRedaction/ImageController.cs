using ImageProcessor;
using ImageProcessor.Imaging;
using ImageProcessor.Imaging.Formats;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoRedaction
{
    class ImageController
    {
        public static byte[] drawFrames(byte[] image, Rectangle[] rectangles)
        {
            byte[] newImg;
            using (Bitmap img = byteToBitmap(image))
            {
                using (Graphics g = Graphics.FromImage(img))
                {
                    g.DrawRectangles(new Pen(Color.Red, 10f), rectangles);
                    newImg = bitmapToByte(img);
                }
            }
            return newImg;
        }                    
                      
        public static byte[] brightness(byte[] image, int percents)
        {
            byte[] photoBytes = image;
            byte[] newImg;
            ISupportedImageFormat format = new JpegFormat { Quality = 70 };
            using (MemoryStream inStream = new MemoryStream(photoBytes))
            {
                using (MemoryStream outStream = new MemoryStream())
                {
                    using (ImageFactory imageFactory = new ImageFactory(preserveExifData: true))
                    {
                        imageFactory.Load(inStream)
                                    .Brightness(percents)
                                    .Format(format)
                                    .Save(outStream);
                    }
                    newImg = outStream.ToArray();
                }
            }
            return newImg;
        }

        public static byte[] shadowing(byte[] image, int percents)
        {
            byte[] photoBytes = image;
            byte[] newImg;

            ISupportedImageFormat format = new JpegFormat { Quality = 70 };
            using (MemoryStream inStream = new MemoryStream(photoBytes))
            {
                using (MemoryStream outStream = new MemoryStream())
                {
                    using (ImageFactory imageFactory = new ImageFactory(preserveExifData: true))
                    {
                        imageFactory.Load(inStream)
                                    .Brightness(-percents)
                                    .Format(format)
                                    .Save(outStream);
                    }
                    newImg = outStream.ToArray();
                }
            }
            return newImg;
        }
                      
        public static byte[] crop(byte[] image, float left,float top, float right, float bottom)
        {

            byte[] photoBytes = image;
            byte[] newImg;
            ISupportedImageFormat format = new JpegFormat { Quality = 70 };
            using (MemoryStream inStream = new MemoryStream(photoBytes))
            {
                using (MemoryStream outStream = new MemoryStream())
                {
                    using (ImageFactory imageFactory = new ImageFactory(preserveExifData: true))
                    {
                        imageFactory.Load(inStream)
                                    .Crop(new CropLayer(left, top, right, bottom, CropMode.Pixels))
                                    .Format(format)
                                    .Save(outStream);
                    }
                    newImg = outStream.ToArray();
                }
            }
            return newImg;
        }
                      
        public static byte[] rotate(byte[] image, float angle)
        {
            byte[] photoBytes = image;
            byte[] newImg;
            ISupportedImageFormat format = new JpegFormat { Quality = 70 };
            using (MemoryStream inStream = new MemoryStream(photoBytes))
            {
                using (MemoryStream outStream = new MemoryStream())
                {
                    using (ImageFactory imageFactory = new ImageFactory(preserveExifData: true))
                    {
                        imageFactory.Load(inStream)
                                    .Rotate(angle)
                                    .Format(format)
                                    .Save(outStream);
                    }
                    newImg = outStream.ToArray();
                }
            }
            return newImg;
        }
                      
        public static byte[] quality(byte[] image, int pixelSize)
        {
            byte[] photoBytes = image;
            byte[] newImg;
            ISupportedImageFormat format = new JpegFormat { Quality = 70 };
            using (MemoryStream inStream = new MemoryStream(photoBytes))
            {
                using (MemoryStream outStream = new MemoryStream())
                {
                    using (ImageFactory imageFactory = new ImageFactory(preserveExifData: true))
                    {
                        imageFactory.Load(inStream)
                                    .Pixelate(pixelSize)
                                    .Format(format)
                                    .Save(outStream);
                    }
                    newImg = outStream.ToArray();
                }
            }
            return newImg;
        }

        private static byte[] bitmapToByte(Bitmap img)
        {
            ImageConverter converter = new ImageConverter();
            byte[] newImg = (byte[])converter.ConvertTo(img, typeof(byte[]));
            img.Dispose();
            return newImg;
        }

        private static Bitmap byteToBitmap(byte[] img)
        {
            Bitmap image;
            using (MemoryStream ms = new MemoryStream(img))
                image = new Bitmap(ms);
            return image;
        }
    }
}
