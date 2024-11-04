using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    public partial class MyMatrix
    {
        public static MyMatrix operator +(MyMatrix matrix1, MyMatrix matrix2)
        {
            if (matrix1.Height == matrix2.Height && matrix1.Width == matrix2.Width)
            {
                MyMatrix result = new MyMatrix(matrix1);

                for (int i = 0; i < result.Height; i++)
                {
                    for (int j = 0; j < result.Width; j++)
                    {
                        result[i, j] += matrix2[i, j];
                    }
                }

                return result;
            }
            else
            {
                throw new ArgumentException("Adding these 2 matrices is impossible due to size mismatch.");
            }
        }

        public static MyMatrix operator *(MyMatrix matrix1, MyMatrix matrix2)
        {
            if (matrix1.Width == matrix2.Height)
            {
                MyMatrix result = new MyMatrix(new double[matrix1.Height, matrix2.Width]);

                for (int i = 0; i < result.Height; i++)
                {
                    for (int j = 0; j < result.Width; j++)
                    {
                        for (int k = 0; k < matrix1.Width; k++)
                        {
                            result[i, j] += matrix1[i, k] * matrix2[k, j];
                        }
                    }
                }

                return result;
            }
            else
            {
                throw new ArgumentException("Multiplying these 2 matrices is impossible due to size mismatch.");
            }
        }

        protected double[,] GetTransponedArray()
        {
            double[,] result = new double[Width, Height];

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    result[j, i] = matrix[i, j];
                }
            }

            return result;
        }

        public MyMatrix GetTransponedCopy()
        {
            double[,] res = GetTransponedArray();

            return new MyMatrix(res);
        }

        public void TransponeMe()
        {
            double[,] res = GetTransponedArray();
            matrix = res; 
        }
    }
}
