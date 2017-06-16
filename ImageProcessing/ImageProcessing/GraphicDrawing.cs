using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;


namespace ImageProcessing
{
    class GraphicDrawing
    {
        public void graphicColumn(int[] liste, Chart chart, string seriesName, Color renk)
        {

            chart.Series.Add(seriesName);
            for (int i = 1; i < liste.Length; i++)
                chart.Series[seriesName].Points.Add(new DataPoint(i, liste[i]));
            chart.Series[seriesName].ChartType = SeriesChartType.Column;
            chart.Series[seriesName].Color = renk;
            chart.Series[seriesName].BorderWidth = 2;
            chart.Series[seriesName].YValueType = ChartValueType.Double;
        }
    }
}
