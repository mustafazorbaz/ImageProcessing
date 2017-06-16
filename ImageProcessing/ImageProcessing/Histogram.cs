using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ImageProcessing
{
    public class HistogramCalculator : ImageProcessing
    {

        Histogram histogram; 
        public override Bitmap make(Bitmap image)
        {
            histogram = new Histogram();
            for (int i = 0; i < image.Height; i++)//satır için
            {
                for (int j = 0; j < image.Width; j++)//sutun için
                {
                    Color pixel = image.GetPixel(j, i);//resimin ilk picselini alır
                    histogram.red[pixel.R]++;
                    histogram.green[pixel.G]++;
                    histogram.blue[pixel.B]++;                  

                }

            }
            return image;
        } 
      
        public Histogram getHistogram()
        {
            return histogram;
        }
        
    }
    public class HistogramEqualization : ImageProcessing
    {
     
        Histogram cumulativeHis = new Histogram();
        Histogram equalHis = new Histogram();
        public override Bitmap make(Bitmap image)
        {
            int pixels = (int)image.Height * (int)image.Width;
            decimal allPixels = 255 / (decimal)pixels;

            //Histgram Hesaplandı
            HistogramCalculator histogramCal  = new HistogramCalculator();
            Bitmap bitmap = histogramCal.make(image);

            //Histogramı kümülatif hesaplama için yolladık.
            cumulativeHis = calculatorCumulativeHistogram(histogramCal.getHistogram()); 

            //Normalizasyon yapıldı
            Normalization normalization = new Normalization();
            
            double[] normalR =normalization.calculat(cumulativeHis.red);
            double[] normalG = normalization.calculat(cumulativeHis.green);
            double[] normalB = normalization.calculat(cumulativeHis.blue);

            for (int i = 0; i < 256; i++)
            {
                equalHis.red[(int)(Math.Floor(normalR[i] * 255))] = histogramCal.getHistogram().blue[i];
                equalHis.green[(int)(Math.Floor(normalG[i] * 255))] = histogramCal.getHistogram().blue[i];
                equalHis.blue[(int)(Math.Floor(normalB[i] * 255))] = histogramCal.getHistogram().blue[i];
            }
            for (int i = 0; i < image.Height; i++)//satır için
            {
                for (int j = 0; j < image.Width; j++)//sutun için
                {
                    Color pixel = image.GetPixel(j, i);//resimin ilk picselini alır
                  int  R = (int)((decimal)cumulativeHis.red[pixel.R] * allPixels);
                  int  G = (int)((decimal)cumulativeHis.green[pixel.G] * allPixels);
                  int  B = (int)((decimal)cumulativeHis.blue[pixel.B] * allPixels);
                    Color newColor = Color.FromArgb(R, G, B);
                    image.SetPixel(j, i, newColor);
                }

            }
            return image;
        }
        public Histogram calculatorCumulativeHistogram(Histogram histogram)
        {
            Histogram cumulativeHistogram = new Histogram();
            int sumB = 0, sumR = 0, sumG = 0;
            for (int i = 0; i < 256; i++)
            {

                if (i == 0)
                {
                    cumulativeHistogram.blue[i] = histogram.blue[i];
                    cumulativeHistogram.green[i] = histogram.green[i];
                    cumulativeHistogram.red[i] = histogram.red[i];
                    sumB = histogram.blue[i];
                    sumR = histogram.red[i];
                    sumG = histogram.green[i];
                }
                if (i > 0)
                {
                    sumB += histogram.blue[i];
                    sumR += histogram.red[i];
                    sumG += histogram.green[i];
                    cumulativeHistogram.blue[i] = sumB;
                    cumulativeHistogram.green[i] = sumG;
                    cumulativeHistogram.red[i] = sumR;

                }
               
            }
            return cumulativeHistogram;
        }
        public Histogram getCumulativeHistogram()
        {
            return equalHis;
        }
    }
    public class Histogram
    {
        public int[] red = new int[256];
        public int[] green = new int[256];
        public int[] blue = new int[256];        
    }
   
        
   
}