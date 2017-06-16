using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ImageProcessing
{
    class Sobel:ImageProcessing
    {
        int[,] sobelArray1 =
          new int[3, 3] {
                    { -1, 0, 1 },
                    { -2, 0, 2 },
                    { -1, 0, 1 }
          };

        int[,] sobelArray2 =
        new int[3, 3] {
                    { -1, -2, -1 },
                    { 0, 0, 0 },
                    {1,2,1 }
        };
        int[,] sobelArray3 =
        new int[3, 3] {
                { 2, 1, 0 },
                { 1, 0,-1 },
                { 0,-1,-2 }
        };
        public override Bitmap make(Bitmap image)
        {
            Gray gray = new Gray();
            image=gray.make(image);
            Bitmap newImage = new Bitmap(image.Width,image.Height);

            int valX, valY,value;
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
                        valX = (image.GetPixel(j - 1, i - 1).R * sobelArray1[0, 0] +
                               image.GetPixel(j  , i - 1).R * sobelArray1[0, 1] +
                               image.GetPixel(j + 1, i - 1).R * sobelArray1[0, 2] +
                               image.GetPixel(j - 1, i).R * sobelArray1[1, 0] +
                               image.GetPixel(j, i).R * sobelArray1[1, 1] +
                               image.GetPixel(j + 1, i).R * sobelArray1[1, 2] +
                               image.GetPixel(j - 1, i + 1).R * sobelArray1[2, 0] +
                               image.GetPixel(j, i + 1).R * sobelArray1[2, 1] +
                               image.GetPixel(j + 1, i + 1).R * sobelArray1[2, 2]
                               );
                        valY = (image.GetPixel(j - 1, i - 1).R * sobelArray2[0, 0] +
                              image.GetPixel(j , i - 1).R * sobelArray2[0, 1] +
                              image.GetPixel(j + 1, i - 1).R * sobelArray2[0, 2] +
                              image.GetPixel(j - 1, i).R * sobelArray2[1, 0] +
                              image.GetPixel(j, i).R * sobelArray2[1, 1] +
                              image.GetPixel(j + 1, i).R * sobelArray2[1, 2] +
                              image.GetPixel(j - 1, i + 1).R * sobelArray2[2, 0] +
                              image.GetPixel(j, i + 1).R * sobelArray2[2, 1] +
                              image.GetPixel(j + 1, i + 1).R * sobelArray2[2, 2]
                              );
                        value = (int)(Math.Abs(valX)+ Math.Abs(valY));
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
