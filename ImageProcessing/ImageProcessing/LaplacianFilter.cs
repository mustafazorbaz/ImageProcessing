using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Windows.Forms.DataVisualization.Charting;

namespace ImageProcessing
{
    class LaplacianFilter: ImageProcessing
    {
       int [,] matriX = new int[,]
                    { { -1, -1, -1,  },
                  { -1,  8, -1,  },
                  { -1, -1, -1,  }, };
        public override Bitmap make(Bitmap image)
        {
            Gray gray = new Gray();
            image = gray.make(image);
            Bitmap newImage = new Bitmap(image.Width, image.Height);

            int val,  value;
            for (int i = 0; i < image.Height; i++)
            {
                for (int j = 0; j < image.Width; j++)
                {
                    if (i == 0 || i == image.Height - 1 || j == 0 || j == image.Width - 1)
                    {
                        Color color;
                        color = Color.FromArgb(255, 255, 255);
                        newImage.SetPixel(j, i, color);
                        val = 0; 
                    }
                    else
                    {
                        val  = (image.GetPixel(j - 1, i - 1).R * matriX[0, 0] +
                               image.GetPixel(j, i - 1).R * matriX[0, 1] +
                               image.GetPixel(j + 1, i - 1).R * matriX[0, 2] +
                               image.GetPixel(j - 1, i).R * matriX[1, 0] +
                               image.GetPixel(j, i).R * matriX[1, 1] +
                               image.GetPixel(j + 1, i).R * matriX[1, 2] +
                               image.GetPixel(j - 1, i + 1).R * matriX[2, 0] +
                               image.GetPixel(j, i + 1).R * matriX[2, 1] +
                               image.GetPixel(j + 1, i + 1).R * matriX[2, 2]
                               );
                      
                        value = (int)(Math.Abs(val)*2);
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
