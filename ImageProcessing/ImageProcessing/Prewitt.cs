using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ImageProcessing
{
    class Prewitt:ImageProcessing
    {
        int[,] PrewittArray1 =
         new int[3, 3] {
        {-1,-1,-1 },
        { 0, 0, 0 },
        { 1, 1, 1 }
         };

                int[,] PrewittArray2 =
                new int[3, 3] {
        { -1, 0, 1 },
        { -1, 0, 1 },
        { -1, 0, 1 }
                };
                int[,] PrewittArray3 =
                new int[3, 3] {
        {-1,-1, 0 },
        {-1, 0, 1 },
        { 0, 1, 1 }
                };

                int[,] PrewittArray4 =
                new int[3, 3] {
        { 1, 1, 0 },
        { 1, 0,-1 },
        { 0,-1,-1 }
                };
        public override Bitmap make(Bitmap image)
        {
            Gray gray = new Gray();
            image = gray.make(image);
            Bitmap newImage = new Bitmap(image.Width, image.Height);

            int valX, valY, value;
            for (int i = 0; i < image.Height; i++)
            {
                for (int j = 0; j < image.Width; j++)
                {
                    if (i == 0 || i == image.Height - 1 || j == 0 || j == image.Width - 1)
                    {
                        Color color;
                        color = Color.FromArgb(255, 255, 255);
                        newImage.SetPixel(j, i, color);
                        valX = 0;
                        valY = 0;
                    }
                    else
                    {
                        valX = (image.GetPixel(j - 1, i - 1).R * PrewittArray1[0, 0] +
                               image.GetPixel(j, i - 1).R * PrewittArray1[0, 1] +
                               image.GetPixel(j + 1, i - 1).R * PrewittArray1[0, 2] +
                               image.GetPixel(j - 1, i).R * PrewittArray1[1, 0] +
                               image.GetPixel(j, i).R * PrewittArray1[1, 1] +
                               image.GetPixel(j + 1, i).R * PrewittArray1[1, 2] +
                               image.GetPixel(j - 1, i + 1).R * PrewittArray1[2, 0] +
                               image.GetPixel(j, i + 1).R * PrewittArray1[2, 1] +
                               image.GetPixel(j + 1, i + 1).R * PrewittArray1[2, 2]
                               );
                        valY = (image.GetPixel(j - 1, i - 1).R * PrewittArray2[0, 0] +
                              image.GetPixel(j, i - 1).R * PrewittArray2[0, 1] +
                              image.GetPixel(j + 1, i - 1).R * PrewittArray2[0, 2] +
                              image.GetPixel(j - 1, i).R * PrewittArray2[1, 0] +
                              image.GetPixel(j, i).R * PrewittArray2[1, 1] +
                              image.GetPixel(j + 1, i).R * PrewittArray2[1, 2] +
                              image.GetPixel(j - 1, i + 1).R * PrewittArray2[2, 0] +
                              image.GetPixel(j, i + 1).R * PrewittArray2[2, 1] +
                              image.GetPixel(j + 1, i + 1).R * PrewittArray2[2, 2]
                              );
                        value = (int)(Math.Abs(valX) + Math.Abs(valY));
                        if (value < 0)
                            value = 0;
                        else if (value > 255)
                            value = 255;
                        Color color = Color.FromArgb(value, value, value);
                        newImage.SetPixel(j, i, color);
                    }
                }
            }
            return newImage;
        }
    }
}
