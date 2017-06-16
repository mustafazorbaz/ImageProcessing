using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageProcessing
{
    class Normalization
    {
        public double[] calculat(int[] array)
        {
            double[] newArray = new double[array.Length];
            double temp = 0;
            for (int i = 0; i < array.Length; i++) //biggest value
            {
                if (array[i] > temp)
                    temp = array[i];
            }
            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] =  Convert.ToDouble(array[i])/ temp;
            }
            Console.WriteLine("-");

           Console.WriteLine("-------arrray-------------");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + ",");
            }
            Console.WriteLine("-");
            Console.WriteLine("-------new array-------------");
            for (int i = 0; i < newArray.Length; i++)
            {
                Console.Write(newArray[i]+",");
            }
            return newArray;
        }
    }
}
