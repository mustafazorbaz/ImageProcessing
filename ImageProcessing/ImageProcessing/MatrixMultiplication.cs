using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImageProcessing
{
    public class MatrixMultiplication
    {
        int[,] matrix1;       
        int[,] matrix2;
        int[,] matrix3;

        double[,] matrixD1; 
        public MatrixMultiplication(int[,] matrix1, int[,] matrix2)
        {
            this.matrix1 = matrix1;
            this.matrix2 = matrix2;
        }
        public MatrixMultiplication(double[,] matrixD1, int[,] matrix2)
        {
            this.matrixD1 = matrixD1;
            this.matrix2 = matrix2;
        }
        public int[,] multiplicationInterger(int x1,int y1,int y2)
        {
            matrix3 = new int[x1+1, y1+1];
            for (int i = 0; i < x1; i++)
                for (int j = 0; j < y2; j++)
                {
                    int deger = 0;
                    for (int c = 0; c < y1; c++)
                    {
                        deger += matrix1[i,c] * matrix2[c,j];
                    }
                    matrix3[i,j] = deger;
                }
            return matrix3;
        }
        public int[,] multiplicationDouble(int x1, int y1, int y2)
        {
            matrix3 = new int[x1 + 1, y1 + 1];
            for (int i = 0; i <x1; i++)
                for (int j = 0; j < y2; j++)
                {
                    double deger = 0;
                    for (int c = 0; c <y1; c++)
                    {
                      //  Console.WriteLine(matrixD1[i, c] +" * "+ matrix2[c, j]);
                        deger += Convert.ToInt32(matrixD1[i, c] * matrix2[c, j]);
                    }
                   // Console.WriteLine("deger" + deger);
                    if (deger > 255)
                        deger = 255;
                    matrix3[i, j] = Convert.ToInt32(deger);
                }
            return matrix3;
        }
    }
}
