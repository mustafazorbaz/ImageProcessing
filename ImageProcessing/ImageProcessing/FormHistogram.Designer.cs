namespace ImageProcessing
{
    partial class FormHistogram
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.chartHistogram = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartHistogram2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartHistogram)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartHistogram2)).BeginInit();
            this.SuspendLayout();
            // 
            // chartHistogram
            // 
            chartArea5.Name = "ChartArea1";
            this.chartHistogram.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.chartHistogram.Legends.Add(legend5);
            this.chartHistogram.Location = new System.Drawing.Point(12, 35);
            this.chartHistogram.Name = "chartHistogram";
            this.chartHistogram.Size = new System.Drawing.Size(458, 269);
            this.chartHistogram.TabIndex = 0;
            this.chartHistogram.Text = "chartHistogram";
            // 
            // chartHistogram2
            // 
            chartArea6.Name = "ChartArea1";
            this.chartHistogram2.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            this.chartHistogram2.Legends.Add(legend6);
            this.chartHistogram2.Location = new System.Drawing.Point(521, 35);
            this.chartHistogram2.Name = "chartHistogram2";
            this.chartHistogram2.Size = new System.Drawing.Size(458, 269);
            this.chartHistogram2.TabIndex = 1;
            this.chartHistogram2.Text = "chart1";
            // 
            // FormHistogram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 380);
            this.Controls.Add(this.chartHistogram2);
            this.Controls.Add(this.chartHistogram);
            this.Name = "FormHistogram";
            this.Text = "HistogramForm";
            this.Load += new System.EventHandler(this.FormHistogram_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartHistogram)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartHistogram2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartHistogram;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartHistogram2;
    }
}