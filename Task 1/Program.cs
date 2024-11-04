using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[,] matrix1 =
            {
                { 1, 2, 3},
                { 4, 5, 6},
                { 7, 8, 9}
            };

            double[,] matrix2 =
            {
                { 1, 2, 3},
                { 4, 5, 6},
                { 7, 8, 9}
            };

            double[,] matrix3 =
            {
                { 1, 2, 3, 4},
                { 5, 6, 7, 8}
            };

            // MatrixData
            MyMatrix m3 = new MyMatrix(matrix3);
            Console.WriteLine(m3.Height);
            Console.WriteLine(m3.getHeight());
            Console.WriteLine(m3.Width);     
            Console.WriteLine(m3.getWidth());
            Console.WriteLine(m3[1, 3]);
            m3[1, 3] = 10;
            Console.WriteLine(m3.ToString());
            Console.WriteLine(m3.getElement(1,2));
            m3.setElement(1, 2, 15);
            Console.WriteLine(m3.ToString());

            // MatrixOperations
            MyMatrix m1 = new MyMatrix(matrix1);
            MyMatrix m2 = new MyMatrix(matrix2);

            MyMatrix adding = m1 + m2;
            Console.WriteLine(adding.ToString());

            MyMatrix multiplying = m1 * m2;
            Console.WriteLine(multiplying.ToString());

            MyMatrix r1 = m1.GetTransponedCopy();
            Console.WriteLine(r1.ToString());

            m1.TransponeMe();
            Console.WriteLine(m1.ToString());
        }
    }
}
