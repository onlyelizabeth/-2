using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Task_1
{
    public partial class MyMatrix
    {
        protected double[,] matrix;

        public double[,] GetMatrix()
        {
            return matrix;
        }

        public MyMatrix(MyMatrix prevMatrix)
        {
            int height = prevMatrix.Height;
            int width = prevMatrix.Width;
            matrix = new double[height, width];

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    matrix[i, j] = prevMatrix.matrix[i, j];
                }
            }
        }

        public MyMatrix(double[,] arr)
        {
            if (arr == null)
            {
                throw new ArgumentNullException("Array cannot be null.");

            }
            if (arr.GetLength(0) == 0 || arr.GetLength(1) == 0)
            {
                throw new ArgumentException("Array dimensions cannot be zero.");
            }

            int rows = arr.GetLength(0);
            int cols = arr.GetLength(1);
            matrix = new double[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = arr[i, j];
                }
            }
        }

        public MyMatrix(double[][] arr)
        {
            if (arr == null)
            {
                throw new ArgumentNullException("Array cannot be null.");
            }

            int rows = arr.Length;
            
            if (rows == 0 || arr[0] == null)
            {
                throw new ArgumentException("Array dimensions cannot be zero.");
            }

            int cols = arr[0].Length;
            for (int i = 0; i < rows; i++)
            {
                if (arr[i].Length != cols)
                    throw new ArgumentException("The jagged array must be rectangular.");
            }

            matrix = new double[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    matrix[i, j] = arr[i][j];
                }
            }
        }

        public MyMatrix(string[] rows)
        {
            int height = rows.Length;
            string[][] temp = new string[height][];

            for (int i = 0; i < height; i++)
            {
                temp[i] = rows[i].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (i > 0 && temp[i].Length != temp[0].Length)
                    throw new ArgumentException("Each row must contain the same number of elements.");
            }

            int width = temp[0].Length;
            matrix = new double[height, width];

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    matrix[i, j] = double.Parse(temp[i][j]);
                }
            }
        }

        public MyMatrix(string matrixString)
        {
            var rows = matrixString.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            int height = rows.Length;
            string[][] temp = new string[height][];

            for (int i = 0; i < height; i++)
            {
                temp[i] = rows[i].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (i > 0 && temp[i].Length != temp[0].Length)
                    throw new ArgumentException("The input string must form a rectangular matrix.");
            }

            int width = temp[0].Length;
            matrix = new double[height, width];

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    matrix[i, j] = double.Parse(temp[i][j]);
                }
            }
        }

        public int Height
        {
            get
            {
                return matrix.GetLength(0);
            }
        }

        public int Width
        {
            get
            {
                return matrix.GetLength(1);
            }
        }

        public int getHeight()
        {
            return Height;
        }

        public int getWidth()
        {
            return Width;
        }

        public double this[int rowNum, int colNum]
        {
            get
            {
                if (rowNum < 0 || rowNum >= Height || colNum < 0 || colNum >= Width)
                {
                    throw new ArgumentOutOfRangeException("Index is out of range.");
                }

                return matrix[rowNum, colNum];
            }

            set
            {
                if (rowNum < 0 || rowNum >= Height || colNum < 0 || colNum >= Width)
                {
                    throw new ArgumentOutOfRangeException("Index is out of range.");
                }

                matrix[rowNum, colNum] = value;
            }
        }

        public double getElement(int rowNum, int colNum)
        {
            if (rowNum < 0 || rowNum >= Height || colNum < 0 || colNum >= Width)
            {
                throw new ArgumentOutOfRangeException("Index is out of range.");
            }

            return matrix[rowNum, colNum];
        }

        public void setElement(int rowNum, int colNum, double value)
        {
            if (rowNum < 0 || rowNum >= Height || colNum < 0 || colNum >= Width)
            {
                throw new ArgumentOutOfRangeException("Index is out of range.");
            }

            matrix[rowNum, colNum] = value;
        }

        public override string ToString()
        {
            var result = new System.Text.StringBuilder();

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    result.Append(matrix[i, j] + "\t");
                }
                result.AppendLine();
            }

            return result.ToString();
        }
    }
}
