using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImageProcessing
{
    public partial class FormHistogram : Form
    { 
        Bitmap bitmap;
        public FormHistogram()
        { 
            InitializeComponent();
        }
        
        public void setBitmap(Bitmap bitmap)
        {
            this.bitmap = bitmap;
        }
        private void FormHistogram_Load(object sender, EventArgs e)
        { 
            HistogramCalculator histogramOrginal = new HistogramCalculator();
            Bitmap bitmap1 = histogramOrginal.make(bitmap);
            orginalHistogram(histogramOrginal.getHistogram());

            HistogramEqualization histogramEqual = new HistogramEqualization();
            Bitmap bitmap2 = histogramEqual.make(bitmap);
            equalHistogram(histogramEqual.getCumulativeHistogram());

           
        }
        public void orginalHistogram(Histogram histogram)
        {
            GraphicDrawing grapgicOrginal = new GraphicDrawing();
            grapgicOrginal.graphicColumn(histogram.red, chartHistogram, "R", Color.Red);
            grapgicOrginal.graphicColumn(histogram.green, chartHistogram, "G", Color.Green);
            grapgicOrginal.graphicColumn(histogram.blue, chartHistogram, "B", Color.Blue);
        }
        public void equalHistogram(Histogram histogram)
        {
            GraphicDrawing equalHistogramGrapgic = new GraphicDrawing();
            equalHistogramGrapgic.graphicColumn(histogram.red, chartHistogram2, "R", Color.Red);
            equalHistogramGrapgic.graphicColumn(histogram.green, chartHistogram2, "G", Color.Green);
            equalHistogramGrapgic.graphicColumn(histogram.blue, chartHistogram2, "B", Color.Blue);
        }
    }
}
