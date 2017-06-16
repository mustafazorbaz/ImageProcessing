using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ImageProcessing
{
    class GaussianFilter : ImageProcessing
    {
        public override Bitmap make(Bitmap image)
        {
            int[,] gaussianPixelArray;


            gaussianPixelArray = new int[image.Width, image.Height];

            int[,] gaussianArray =
            new int[5, 5] {
                {1,4,7,4,1},
                {4,16,26,16,4},
                {7,26,41,26,7},
                {4,16,26,16,4},
                {1,4,7,4,1}
            };
            int tempSumR, tempSumG, tempSumB;

            for (int i = 2; i < image.Height - 2; i++)
            {
                for (int j = 2; j < image.Width - 2; j++)
                {
                    tempSumR = 0; tempSumG = 0; tempSumB = 0;
                    for (int k = -2; k < 3; k++)
                    {
                        for (int l = -2; l < 3; l++)
                        {
                            Color pixel = image.GetPixel(j + l, i + k);
                            tempSumR += pixel.R * gaussianArray[k + 2, l + 2];
                            tempSumG += pixel.G * gaussianArray[k + 2, l + 2];
                            tempSumB += pixel.B * gaussianArray[k + 2, l + 2];
                        }
                    }
                    Color color = Color.FromArgb(tempSumR / 273, tempSumG / 273, tempSumB / 273);
                    image.SetPixel(j, i, color);
                }
            }


            return image;
        }

    
    }  
}
