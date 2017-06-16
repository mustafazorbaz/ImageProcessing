using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace ImageProcessing
{
    public partial class Form1 : Form
    {
        ImageProcessing operation;
        Bitmap imageFirst;
        public Form1()
        {
            InitializeComponent();
        }
        public void setPictureBox(Image image)
        { 
            pictureBox2.Image = image;
        }
        private void transact_Click(object sender, EventArgs e)
        { if (textBoxResimYolu.Text != "" && comboBox1.Text != "")
            {
                imageFirst = new Bitmap(pictureBox1.Image);//url deki buluna png uzantılı resmi bitsel olarak islem yaptır mak için nesne olusturulur
                String operationName = comboBox1.Text; //Operasyon ismini yazıyoruz.
                int value = Convert.ToInt32(textBoxValue.Text);
                int x = Convert.ToInt32(textBoxX.Text);
                int y = Convert.ToInt32(textBoxY.Text);
                int tresholding = Convert.ToInt32(textBoxTresholding.Text);
                if (operationName == "Gri Yap")
                    operation = new Gray();
                else if (operationName == "Negatif Yap")
                    operation = new Negative();
                else if (operationName == "Test Çevir")
                    operation = new Reverse();
                else if (operationName == "Aynalama")
                    operation = new Mirroring();
                else if (operationName == "Döndürme")
                    operation = new Rotate(value);
                else if (operationName == "Öteleme")
                    operation = new ShiftXY(x, y); 
                else if (operationName == "Zoom")
                    operation = new Zoom();
                else if (operationName == "Uzaklaştırma")
                    operation = new Removal();
                else if (operationName == "Kanal Ayırma - Kırmızı")
                    operation = new ChannelSeparation(1);
                else if (operationName == "Kanal Ayırma - Yeşil")
                    operation = new ChannelSeparation(2);
                else if (operationName == "Kanal Ayırma - Mavi")
                    operation = new ChannelSeparation(3);
                else if (operationName == "Kanal Çevirme")
                    operation = new ChannelTranslation();
                else if (operationName == "Gri Seviye Dönüşümü")
                    operation = new GrayLevelTransformation();
                else if (operationName == "Sepya Dönüşümü")
                    operation = new SepiaTransformation();
                else if (operationName == "Histogram  Germe")
                    operation = new HistogramStretching();
                else if (operationName == "Görüntü Eşikleme")
                    operation = new ImageTresholding(tresholding);
                else if (operationName == "Otsu")
                    operation = new Otsu();
                else if (operationName == "Sobel")
                    operation = new Sobel();
                else if (operationName == "Gaussian")
                    operation = new GaussianFilter();
                else if (operationName == "Prewitt")
                    operation = new Prewitt();
                else if (operationName == "Laplacian")
                    operation = new LaplacianFilter();

                Bitmap imageLast = operation.make(imageFirst);
                pictureBox2.Image = imageLast;

            }
            else
                MessageBox.Show("Boş değer girilemez...");
        }
      
        private void butonResimSec_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog(); //Dosyamızı açmamıza yarayan nesneyi oluşturduk
            //openDialog.Filter = "Image Files(*.png)|*.png";   //png tipinde oluştruduk
           // openDialog.InitialDirectory = @"C:\Users\Mustafa\Destop";

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxResimYolu.Text = openDialog.FileName.ToString();
                pictureBox1.ImageLocation = textBoxResimYolu.Text;
                //textBoxResimYolu.Enabled = false;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image != null)
            {
                //Bu kısımda resmi kaydetmek için
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Filter = "Bitmap Image (.bmp)|*.bmp|Gif Image (.gif)|*.gif|JPEG Image (.jpeg)|*.jpeg|Png Image (.png)|*.png|Tiff Image (.tiff)|*.tiff|Wmf Image (.wmf)|*.wmf";
                if (saveFile.ShowDialog() == DialogResult.OK)
                {

                    pictureBox2.Image.Save(saveFile.FileName.ToString());

                }
            }else
            {
                MessageBox.Show("İşlenmiş resim yok...");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxResimYolu.Text != "" && comboBox1.Text != "")
            {

                imageFirst = new Bitmap(pictureBox1.Image);
                FormHistogram frm = new FormHistogram();
                frm.setBitmap(imageFirst);
                frm.Show();
            }
            else
                MessageBox.Show("Boş değer girilemez...");
        }

        private void buttonColorMapping_Click(object sender, EventArgs e)
        {
            if (textBoxResimYolu.Text != "")
            {
                imageFirst = new Bitmap(pictureBox1.Image);//url deki buluna png uzantılı resmi bitsel olarak islem yaptır mak için nesne olusturulur
                String operationName = comboBox1.Text; //Operasyon ismini yazıyoruz.
                int r = Convert.ToInt32(textBoxR.Text);
                int g = Convert.ToInt32(textBoxG.Text);
                int b = Convert.ToInt32(textBoxB.Text);

                operation = new ColorMapping(r, g, b);

                Bitmap imageLast = operation.make(imageFirst);
                pictureBox2.Image = imageLast;
            }
            else
                MessageBox.Show("Boş değer girilemez...");
        }
    }
}
