using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ImageProcessing
{
    public abstract class ImageProcessing
    {
        public abstract Bitmap make(Bitmap image); 

    }
    public class Gray : ImageProcessing
    {
        public override Bitmap make(Bitmap image)
        {
            for (int i = 0; i < image.Height; i++)//satır için
            {
                for (int j = 0; j < image.Width; j++)//sutun için
                {
                    Color pixel = image.GetPixel(j, i);//resimin ilk picselini alır
                    int differentValue = (pixel.R + pixel.G + pixel.B) / 3;
                    Color color;
                    color = Color.FromArgb(differentValue, differentValue, differentValue);
                    image.SetPixel(j, i, color);
                }

            }
            return image;
        }

    }

    public class Negative : ImageProcessing
    {
        public override Bitmap make(Bitmap image)
        {
            for (int i = 0; i < image.Height; i++)//satır için
            {
                for (int j = 0; j < image.Width; j++)//sutun için
                {
                    Color pixel = image.GetPixel(j, i);//resimin ilk picselini alır
                    Color color;
                    color = Color.FromArgb(255 - pixel.R, 255 - pixel.G, 255 - pixel.B);
                    image.SetPixel(j, i, color);
                }

            }
            return image;
        }
    }
    public class Reverse : ImageProcessing
    {
        public override Bitmap make(Bitmap image)
        {

            Bitmap tempImage = new Bitmap(image);

            for (int i = 0; i < image.Height; i++)
            {
                for (int j = 0; j < image.Width; j++)//sutun için
                {

                    Color temp = image.GetPixel(j, (image.Height - 1) - i);
                    tempImage.SetPixel(j, i, temp);

                }

            }
            return tempImage;
        }
    }

    public class Mirroring : ImageProcessing
    {
        public override Bitmap make(Bitmap image)
        {
            Bitmap tempImage = new Bitmap(image);
            for (int i = 0; i < image.Height; i++)
            {
                for (int j = 0; j < image.Width; j++)//sutun için
                {

                    Color temp = image.GetPixel((image.Width - 1) - j, i);
                    tempImage.SetPixel(j, i, temp);
                }

            }
            return tempImage;
        }
    }
    public class Rotate : ImageProcessing
    {
        int rotate;
        public Rotate(int rotate)
        {
            this.rotate = rotate;
        }
        public override Bitmap make(Bitmap image)
        {
            System.Drawing.Imaging.PixelFormat pixel = default(System.Drawing.Imaging.PixelFormat);
            rotate = rotate % 360;
            if (rotate > 180)
                rotate -= 360;
            Color color=Color.White;
            if (color == Color.Transparent)
            {
                pixel = System.Drawing.Imaging.PixelFormat.Format32bppArgb;
            }
            else
            {
                pixel = image.PixelFormat;
            }

            float sin = (float)Math.Abs(Math.Sin(rotate * Math.PI / 180.0)); // this function takes radians
            float cos = (float)Math.Abs(Math.Cos(rotate * Math.PI / 180.0)); // this one too
            float imageWitdh = sin * image.Height + cos * image.Width;
            float imageHeight = sin * image.Width + cos * image.Height;
            float X = 0f;
            float Y = 0f;

            if (rotate > 0)
            {
                if (rotate <= 90)
                    X = sin * image.Height;
                else
                {
                    X = imageWitdh;
                    Y = imageHeight - sin * image.Width;
                }
            }
            else
            {
                if (rotate >= -90)
                {
                    Y = sin * image.Width;
                }
                else
                {
                    X = imageWitdh - sin * image.Height;
                    Y = imageHeight;
                }
            }

            Bitmap bmp = new Bitmap((int)imageWitdh, (int)imageHeight, pixel);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(color);
            g.TranslateTransform(X, Y);
            g.RotateTransform(rotate);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            g.DrawImageUnscaled(image, 0, 0);
            g.Dispose();
            return bmp;
        
        }
    
    }
    public class ShiftXY : ImageProcessing
    {
        private int coordinateX,coordinateY;
        public ShiftXY(int x,int y)
        {
            coordinateX = x;
            coordinateY = y;
        }
        public override Bitmap make(Bitmap image)
        {
            Bitmap tempImage = new Bitmap(image.Width+ coordinateX, image.Height+coordinateY);
          
            for (int i = 0; i < image.Height; i++)
            {
                for (int j = 0; j < image.Width; j++)//sutun için
                { 
                    Color temp = image.GetPixel(j, i);
                    tempImage.SetPixel(j+ coordinateX, i+ coordinateY, temp);
                }

            }
            return tempImage;
        }
    }
    public class Zoom : ImageProcessing
    {
        public override Bitmap make(Bitmap image)
        {
            //Bitmap tempImage = new Bitmap(image);
            int i1 = 0, j1=0;
            Bitmap tempImage = new Bitmap(image.Width * 2 - 1, image.Height * 2 - 1);
            for (int i = 0; i < tempImage.Height; i++)
            {
                for (int j = 0; j < tempImage.Width; j++)//sutun için
                {
                    if (i % 2 == 0 && j % 2 == 0) //A
                    {
                        Color temp = image.GetPixel(j1, i1);
                        //Color temp = Color.FromArgb(0, 255,0);

                        tempImage.SetPixel(j, i, temp);
                        j1++;
                    }
                }
                if (i % 2 == 0) 
                {
                    i1++;
                    j1 = 0;
                }
            }

            for (int i = 0; i < tempImage.Height; i++)
            {
                for (int j = 0; j < tempImage.Width; j++)//sutun için
                {
                     if (i % 2 != 0 && j % 2 == 0) // (A+D)/2 Dikey
                    {
                        int tempJ1 = i, tempJ2 = i;
                         tempJ1++;
                         tempJ2--;
                       Color pixel1 = tempImage.GetPixel(j, tempJ1);
                        Color pixel2 = tempImage.GetPixel(j, tempJ2);
                        Color color = Color.FromArgb((pixel1.R + pixel2.R) / 2, (pixel1.G + pixel2.G) / 2, (pixel1.B + pixel2.B) / 2);
                        
                         // Color color = Color.FromArgb(255, 255,255);
                       tempImage.SetPixel(j, i, color);
                    }
                    else if (i % 2 == 0 && j % 2 != 0) // (A+B)/2 Yatay
                    {
                        int tempI1 = j, tempI2 = j;
                        tempI1++;
                        tempI2--;
                        Color pixel1 = tempImage.GetPixel(tempI1, i );
                        Color pixel2 = tempImage.GetPixel(tempI2,i);
                        Color color = Color.FromArgb((pixel1.R + pixel2.R) / 2, (pixel1.G + pixel2.G) / 2, (pixel1.B + pixel2.B) / 2);
                         
                        tempImage.SetPixel(j, i, color);
                    }
                    else if (i % 2 != 0 && j % 2 != 0) // (A+B+D+E)/4
                    {
                        int tempI1 = j, tempJ1 = i;
                        tempI1--; tempJ1--; ; 
                        int tempI2 = j, tempJ2 = i;
                        tempI2++; tempJ2--; ;
                        int tempI3 = j, tempJ3 = i;
                        tempI3--; tempJ3++;
                        int tempI4 = j, tempJ4 = i;
                        tempI4++; tempJ4++;

                        Color pixel1 = tempImage.GetPixel(tempI1, tempJ1);
                        Color pixel2 = tempImage.GetPixel(tempI2, tempJ2);
                        Color pixel3 = tempImage.GetPixel(tempI3, tempJ3);
                        Color pixel4 = tempImage.GetPixel(tempI4, tempJ4); 
                        Color color = Color.FromArgb((pixel1.R + pixel2.R+ pixel3.R + pixel4.R) / 4,
                                                        (pixel1.G + pixel2.G + pixel3.G + pixel4.G) / 4,
                                                       (pixel1.B + pixel2.B + pixel3.B + pixel4.B) / 4);

                        tempImage.SetPixel(j, i, color);

                    }
                }
            }
                    return tempImage;
        }
    }
    public class Removal:ImageProcessing
    {
        public override Bitmap make(Bitmap image)
        {
            int widthA = image.Width % 2;
            int width = image.Width / 2 + widthA;
            int heightA = image.Height % 2;
            int height = image.Width / 2 + heightA;
            List<Row> row = new List<Row>();
            Bitmap bitmap = new Bitmap(width, height);
             
            int i1=0, j1 = 0;
            for (int i = 0; i < image.Height; i++)
            {
                int sumR = 0, sumG = 0, sumB = 0;
                int indis = 0;
                for (int j = 0; j < image.Width; j++)//sutun için
                {


                    Color pixel = image.GetPixel(j, i);
                    sumR += pixel.R;
                    sumG += pixel.G;
                    sumB += pixel.B;

                    if (j % 2 != 0)
                    {
                        row.Add(new Row(sumR / 2, sumG / 2, sumB / 2));
                        sumR = 0;
                        sumG = 0;
                        sumB = 0;
                    }
                    if (i % 2 != 0 && j % 2 != 0)
                    {
                        sumR = (sumR / 2 + row[indis].getR());
                        sumG = (sumG / 2 + row[indis].getG());
                        sumB = (sumB / 2 + row[indis].getB());
                        Color color = Color.FromArgb(sumR, sumG, sumB);
                        bitmap = new Bitmap(image,width, height);
                        
                        // bitmap.SetPixel(j1, i1, color);
                        sumR = 0;
                        sumG = 0;
                        sumB = 0;
                        j1 ++;
                    }
                }
                if (i % 2 != 0)
                {
                    row.Clear();
                    i1++;
                    j1 = 0;
                }
            }
            return bitmap;
        }
    }
    public class ChannelSeparation : ImageProcessing
    {
        int[,] matrisRed = new int[,] {{ 1, 0,0,0 }, {0, 0,0,0 }, { 0, 0,0,0 } };
        int[,] matrisGreen = new int[,] {{ 0, 0,0,0 }, { 0, 1,0,0 }, { 0, 0,0,0 }};
        int[,] matrisBlue = new int[,] {{ 0, 0,0,0 }, { 0, 0,0,0 },{ 0, 0,1,0 }};
        int selecter;
        public ChannelSeparation(int selecter)
        {
            this.selecter = selecter;
        }
        public override Bitmap make(Bitmap image)
        {
            for (int i = 0; i < image.Height; i++)//satır için
            {
                for (int j = 0; j < image.Width; j++)//sutun için
                {
                    Color pixel = image.GetPixel(j, i);//resimin ilk picselini alır
                    int [,]matrisRGB = new int[4, 1];
                    matrisRGB[0, 0] = pixel.R;
                    matrisRGB[1, 0] = pixel.G;
                    matrisRGB[2, 0] = pixel.B;
                    matrisRGB[3, 0] = 1;
                    MatrixMultiplication matris=null;
                   if (selecter==1)
                        matris = new MatrixMultiplication(matrisRed, matrisRGB);
                   if (selecter ==2)
                        matris = new MatrixMultiplication(matrisGreen, matrisRGB);
                   if (selecter == 3)
                        matris = new MatrixMultiplication(matrisBlue, matrisRGB);

                    int[,] newMatrixRGB =matris.multiplicationInterger(3,4,1); //x1,y1,y2
                    Color color;
                    color = Color.FromArgb(newMatrixRGB[0, 0], newMatrixRGB[1, 0], newMatrixRGB[2, 0]);
                    image.SetPixel(j, i, color);
                }
            }
            return image;
        }
    }
    public class ChannelTranslation : ImageProcessing
    { 
        int[,] matrix = new int[,] { { -1, 0, 0, 255 }, { 0, -1, 0, 255 }, { 0, 0, -1, 255 } };
         
       
        public override Bitmap make(Bitmap image)
        {
            for (int i = 0; i < image.Height; i++)//satır için
            {
                for (int j = 0; j < image.Width; j++)//sutun için
                {
                    Color pixel = image.GetPixel(j, i);//resimin ilk picselini alır
                    int[,] matrisRGB = new int[4, 1];
                    matrisRGB[0, 0] = pixel.R;
                    matrisRGB[1, 0] = pixel.G;
                    matrisRGB[2, 0] = pixel.B;
                    matrisRGB[3, 0] = 1;
                    MatrixMultiplication newMatrix = new MatrixMultiplication(matrix, matrisRGB);

                    int[,] newMatrixRGB = newMatrix.multiplicationInterger(3, 4, 1); //x1,y1,y2
                    Color color;
                    color = Color.FromArgb(newMatrixRGB[0, 0], newMatrixRGB[1, 0], newMatrixRGB[2, 0]);
                    image.SetPixel(j, i, color);
                }
            }
            return image;
        }
    }
    public class GrayLevelTransformation : ImageProcessing
    {
        double[,] matrix = new double[,] { { 0.299,0.587,0.114,0 }, { 0.299, 0.587, 0.114, 0 }, { 0.299, 0.587, 0.114, 0 } };


        public override Bitmap make(Bitmap image)
        {
            for (int i = 0; i < image.Height; i++)//satır için
            {
                for (int j = 0; j < image.Width; j++)//sutun için
                {
                    Color pixel = image.GetPixel(j, i);//resimin ilk picselini alır
                    int[,] matrisRGB = new int[4, 1];
                    matrisRGB[0, 0] = pixel.R;
                    matrisRGB[1, 0] = pixel.G;
                    matrisRGB[2, 0] = pixel.B;
                    matrisRGB[3, 0] = 1;
                    MatrixMultiplication newMatrix = new MatrixMultiplication(matrix, matrisRGB);

                    int[,] newMatrixRGB = newMatrix.multiplicationDouble(3, 4, 1); //x1,y1,y2
                    Color color;
                    color = Color.FromArgb(newMatrixRGB[0, 0], newMatrixRGB[1, 0], newMatrixRGB[2, 0]);
                    image.SetPixel(j, i, color);
                }
            }
            return image;
        }
    }
    public class SepiaTransformation : ImageProcessing
    {
        double[,] matrix = new double[,] { { 0.393, 0.769, 0.189, 0 }, { 0.349, 0.686, 0.168, 0 }, { 0.272, 0.534, 0.131, 0 } };


        public override Bitmap make(Bitmap image)
        {
            for (int i = 0; i < image.Height; i++)//satır için
            {
                for (int j = 0; j < image.Width; j++)//sutun için
                {
                    Color pixel = image.GetPixel(j, i);//resimin ilk picselini alır
                    int[,] matrisRGB = new int[4, 1];
                    matrisRGB[0, 0] = pixel.R;
                    matrisRGB[1, 0] = pixel.G;
                    matrisRGB[2, 0] = pixel.B;
                    matrisRGB[3, 0] = 1;
                    MatrixMultiplication newMatrix = new MatrixMultiplication(matrix, matrisRGB);

                    int[,] newMatrixRGB = newMatrix.multiplicationDouble(3, 4, 1); //x1,y1,y2
                    Color color;
                    color = Color.FromArgb(newMatrixRGB[0, 0], newMatrixRGB[1, 0], newMatrixRGB[2, 0]);
                    image.SetPixel(j, i, color);
                }
            }
            return image;
        }
    }
    public class HistogramStretching : ImageProcessing
    {
        public override Bitmap make(Bitmap image)
        {
            
            HistogramCalculator histogramCalculator = new HistogramCalculator();
            histogramCalculator.make(image);

            Histogram sortHistogram = new Histogram(); //Orginal
            sortHistogram = histogramCalculator.getHistogram();
            Array.Sort<int>(sortHistogram.red,new Comparison<int>((i1, i2) => i1.CompareTo(i2)));
            Array.Sort<int>(sortHistogram.green,new Comparison<int>( (i1, i2) => i1.CompareTo(i2)));
            Array.Sort<int>(sortHistogram.blue, new Comparison<int>((i1, i2) => i1.CompareTo(i2)));

            int A = 255, B = 0;
            for (int i = 0; i < image.Height; i++)//satır için
            {
                for (int j = 0; j < image.Width; j++)//sutun için
                {
                    Color pixel = image.GetPixel(j, i);//resimin ilk picselini alır
                    int r1 = (byte)((A - B) * (pixel.R - sortHistogram.red[255]) / (sortHistogram.red[255] - sortHistogram.red[0]) + B);
                    int g1 = (byte)((A - B) * (pixel.G - sortHistogram.green[255]) / (sortHistogram.green[255] - sortHistogram.green[0]) + B);
                    int b1 = (byte)((A - B) * (pixel.B - sortHistogram.blue[255]) / (sortHistogram.blue[255] - sortHistogram.blue[0]) + B);
                    image.SetPixel(j, i, Color.FromArgb(r1, g1, b1));

                }

            }
            return image;
        }
    }
    public class ImageTresholding : ImageProcessing
    {
        int t;
        public ImageTresholding(int t)
        {
            this.t = t;
        }
        public override Bitmap make(Bitmap orginalImage)
        {
           Gray operation = new Gray();           
            Bitmap image = operation.make(orginalImage);
            

            for (int i = 0; i < image.Height; i++)//satır için
            {
                for (int j = 0; j < image.Width; j++)//sutun için
                {
                    Color pixel = image.GetPixel(j, i);
                    Color color;
                    if (t >  pixel.R   )
                      color = Color.FromArgb(0, 0, 0);
                    else
                        color = Color.FromArgb(255, 255, 255);
                    image.SetPixel(j, i, color);
                }

            }
            return image;
        }
    }
   public class Otsu : ImageProcessing
    {
        public override Bitmap make(Bitmap image)
        {
            Gray gray = new Gray();
            image = gray.make(image);

            HistogramCalculator calHistogram = new HistogramCalculator();
            calHistogram.make(image);
            Histogram histogram = calHistogram.getHistogram();

           ImageTresholding img= new ImageTresholding(otsuAlgorithm(histogram.blue));

            return img.make(image);

        }
        private int otsuAlgorithm(int[] histogram)
        {
            int otsuValue = 150;
            double fmax = -1.0;
            double m1, m2, S, toplam1 = 0.0, toplam2 = 0.0;
            double nTop = 0, n1 = 0, n2;

            for (int i = 0; i < 256; i++)
            {
                toplam1 += i * Convert.ToDouble(histogram[i]);
                nTop += Convert.ToDouble(histogram[i]);
            }

            for (int i = 0; i < 256; i++)
            {
                n1 += Convert.ToDouble(histogram[i]);
                if (n1 == 0)
                    continue;
                n2 = nTop - n1;
                if (n2 == 0)
                    break;
                toplam2 += i * Convert.ToDouble(histogram[i]);
                m1 = toplam2 / n1;
                m2 = (toplam1 - toplam2) / n2;
                S = n1 * n2 * (m1 - m2) * (m1 - m2);
                if (S > fmax)
                {
                    fmax = S;
                    otsuValue = i;
                }
            }
            return otsuValue;
        }

    }
    public class ImageFilter : ImageProcessing
    {
        public override Bitmap make(Bitmap image)
        {
            throw new NotImplementedException();
        }

    }
    public class ColorMapping : ImageProcessing
    {
        int r, g, b;
        Color color;
        public ColorMapping(int r,int g,int b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
        }
        public override Bitmap make(Bitmap image)
        {
            bool state = true;
            for (int i = 0; i < image.Height; i++)//satır için
            {
                for (int j = 0; j < image.Width; j++)//sutun için
                {
                    Color pixel = image.GetPixel(j, i);//resimin ilk picselini alır

                    if ((pixel.R + r < 256) && (pixel.G + g < 256) && (pixel.B + b < 256))
                        color = Color.FromArgb(pixel.R + r, pixel.G + g, pixel.B + b);
                    else
                        color = Color.FromArgb(pixel.R , pixel.G, pixel.B);
                    image.SetPixel(j, i, color);
                }
                if (state == false)
                    break;
            }
            return image;
        }

    }
}