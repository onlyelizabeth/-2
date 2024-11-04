using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task_1;
using System;

namespace Tests_Task_1
{
    [TestClass]
    public class UnitTest1
    {
        // MatrixData

        [TestMethod]
        public void Constructor_WithArray_InitializesMatrix()
        {
            double[,] expectedMatrix = { { 1, 2 }, { 3, 4 } };
            MyMatrix matrix = new MyMatrix(expectedMatrix);

            double[,] actualMatrix = matrix.GetMatrix();

            Assert.AreEqual(expectedMatrix.GetLength(0), actualMatrix.GetLength(0), "Row count does not match.");
            Assert.AreEqual(expectedMatrix.GetLength(1), actualMatrix.GetLength(1), "Column count does not match.");

            for (int i = 0; i < expectedMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < expectedMatrix.GetLength(1); j++)
                {
                    Assert.AreEqual(expectedMatrix[i, j], actualMatrix[i, j], $"Element at ({i}, {j}) does not match.");
                }
            }
        }


        [TestMethod]
        public void Constructor_WithJaggedArray_InitializesMatrix()
        {
            double[][] arr = new double[][] { new double[] { 1, 2 }, new double[] { 3, 4 } };
            MyMatrix matrix = new MyMatrix(arr);

            Assert.AreEqual(2, matrix.Height);
            Assert.AreEqual(2, matrix.Width);
        }

        [TestMethod]
        public void Constructor_WithStringArray_InitializesMatrix()
        {
            string[] rows = { "1 2", "3 4" };
            MyMatrix matrix = new MyMatrix(rows);

            Assert.AreEqual(2, matrix.Height);
            Assert.AreEqual(2, matrix.Width);
            Assert.AreEqual(1, matrix[0, 0]);
            Assert.AreEqual(4, matrix[1, 1]);
        }

        [TestMethod]
        public void Constructor_WithString_InitializesMatrix()
        {
            string matrixString = "1 2\n3 4";
            MyMatrix matrix = new MyMatrix(matrixString);

            Assert.AreEqual(2, matrix.Height);
            Assert.AreEqual(2, matrix.Width);
            Assert.AreEqual(1, matrix[0, 0]);
            Assert.AreEqual(4, matrix[1, 1]);
        }

        [TestMethod]
        public void Indexer_GetAndSetValue_ReturnsAndUpdatesElement()
        {
            double[,] arr = { { 1, 2 }, { 3, 4 } };
            MyMatrix matrix = new MyMatrix(arr);

            Assert.AreEqual(3, matrix[1, 0]);

            matrix[1, 0] = 5;
            Assert.AreEqual(5, matrix[1, 0]);
        }

        [TestMethod]
        public void GetElement_ReturnsCorrectValue()
        {
            double[,] arr = { { 1, 2 }, { 3, 4 } };
            MyMatrix matrix = new MyMatrix(arr);

            Assert.AreEqual(3, matrix.getElement(1, 0));
        }

        [TestMethod]
        public void SetElement_UpdatesValueCorrectly()
        {
            double[,] arr = { { 1, 2 }, { 3, 4 } };
            MyMatrix matrix = new MyMatrix(arr);

            matrix.setElement(1, 0, 5);
            Assert.AreEqual(5, matrix[1, 0]);
        }

        [TestMethod]
        public void Constructor_WithNullArray_ThrowsArgumentNullException()
        {
            double[,] arr = null;

            var ex = Assert.ThrowsException<ArgumentNullException>(() =>
            {
                var matrix = new MyMatrix(arr); // Спроба передати null масив
            });

            Assert.IsTrue(ex.Message.Contains("Array cannot be null."));
        }

        [TestMethod]
        public void Constructor_WithJaggedArray_NullArray_ThrowsArgumentNullException()
        {
            double[][] arr = null;

            var ex = Assert.ThrowsException<ArgumentNullException>(() =>
            {
                var matrix = new MyMatrix(arr); // Спроба передати null джаггед масив
            });

            Assert.IsTrue(ex.Message.Contains("Array cannot be null."));
        }


        [TestMethod]
        public void Constructor_WithEmptyArray_ThrowsArgumentException()
        {
            double[,] arr = new double[0, 0];
            var ex = Assert.ThrowsException<ArgumentException>(() => new MyMatrix(arr));
            Assert.AreEqual("Array dimensions cannot be zero.", ex.Message);
        }

        [TestMethod]
        public void Constructor_WithJaggedArray_EmptyArray_ThrowsArgumentException()
        {
            double[][] arr = new double[0][];

            var ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                var matrix = new MyMatrix(arr);
            });

            Assert.IsTrue(ex.Message.Contains("Array dimensions cannot be zero."));
        }


        [TestMethod]
        public void Constructor_WithNonRectangularJaggedArray_ThrowsArgumentException()
        {
            double[][] arr = new double[][] { new double[] { 1, 2 }, new double[] { 3 } };
            var ex = Assert.ThrowsException<ArgumentException>(() => new MyMatrix(arr));
            Assert.AreEqual("The jagged array must be rectangular.", ex.Message);
        }

        [TestMethod]
        public void Constructor_WithInvalidStringArray_ThrowsFormatException()
        {
            string[] rows = { "1 a", "3 4" };  // Неправильний формат елементу "a"
            var ex = Assert.ThrowsException<FormatException>(() => new MyMatrix(rows));
            Assert.IsTrue(ex.Message.Contains("Input string was not in a correct format."));
        }

        [TestMethod]
        public void Constructor_WithInconsistentStringArray_ThrowsArgumentException()
        {
            string[] rows = { "1 2", "3" };  // Рядки різної довжини
            var ex = Assert.ThrowsException<ArgumentException>(() => new MyMatrix(rows));
            Assert.AreEqual("Each row must contain the same number of elements.", ex.Message);
        }

        [TestMethod]
        public void Indexer_Get_InvalidIndex_ThrowsArgumentOutOfRangeException()
        {
            double[,] arr = { { 1, 2 }, { 3, 4 } };
            MyMatrix matrix = new MyMatrix(arr);

            var ex = Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                var value = matrix[2, 0]; // Спроба доступу до недійсного індексу
            });

            Assert.IsTrue(ex.Message.Contains("Index is out of range."));
        }

        [TestMethod]
        public void Indexer_Set_InvalidIndex_ThrowsArgumentOutOfRangeException()
        {
            double[,] arr = { { 1, 2 }, { 3, 4 } };
            MyMatrix matrix = new MyMatrix(arr);

            var ex = Assert.ThrowsException<ArgumentOutOfRangeException>(() => matrix[2, 0] = 5);
            Assert.IsTrue(ex.Message.Contains("Index is out of range."));
        }

        [TestMethod]
        public void GetElement_InvalidIndex_ThrowsArgumentOutOfRangeException()
        {
            double[,] arr = { { 1, 2 }, { 3, 4 } };
            MyMatrix matrix = new MyMatrix(arr);

            var ex = Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                var value = matrix.getElement(2, 0); // Спроба доступу до недійсного індексу
            });

            Assert.IsTrue(ex.Message.Contains("Index is out of range."));
        }

        [TestMethod]
        public void SetElement_InvalidIndex_ThrowsArgumentOutOfRangeException()
        {
            double[,] arr = { { 1, 2 }, { 3, 4 } };
            MyMatrix matrix = new MyMatrix(arr);

            var ex = Assert.ThrowsException<ArgumentOutOfRangeException>(() => matrix.setElement(2, 0, 5));
            Assert.IsTrue(ex.Message.Contains("Index is out of range."));
        }

        [TestMethod]
        public void ToString_ReturnsCorrectStringRepresentation()
        {
            double[,] arr = { { 1, 2 }, { 3, 4 } };
            MyMatrix matrix = new MyMatrix(arr);

            string expected = "1\t2\t\n3\t4\t\n";
            string actual = matrix.ToString().Replace("\r", "");

            Assert.AreEqual(expected, actual);
        }


        // MatrixOperations
        [TestMethod]
        public void OperationAdding_ShouldWorkCorrectly()
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

            double[,] result =
            {
                { 2, 4, 6 },
                { 8, 10, 12 },
                { 14, 16, 18 }
            };

            MyMatrix m1 = new MyMatrix(matrix1);
            MyMatrix m2 = new MyMatrix(matrix2);

            MyMatrix adding = m1 + m2;

            bool res = true;

            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    if (result[i, j] != adding.GetMatrix()[i, j])
                    {
                        res = false;
                    }
                }
            }

            Assert.IsTrue(res);
        }

        [TestMethod]
        public void OperationAdding_ShouldThrowException()
        {
            double[,] matrix1 =
            {
                { 1, 2, 3},
                { 4, 5, 6},
                { 7, 8, 9}
            };

            double[,] matrix2 =
            {
                { 1, 2, 3, 10},
                { 4, 5, 6, 11},
                { 7, 8, 9, 12}
            };

            MyMatrix m1 = new MyMatrix(matrix1);
            MyMatrix m2 = new MyMatrix(matrix2);



            var exception = Assert.ThrowsException<ArgumentException>(() =>
            {
                MyMatrix adding = m1 + m2;
            });

            Assert.AreEqual("Adding these 2 matrices is impossible due to size mismatch.", exception.Message);
        }

        [TestMethod]
        public void OperationMultiplying_ShouldWorkCorrectly()
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

            double[,] result =
            {
                { 30, 36, 42 },
                { 66, 81,  96},
                { 102, 126, 150 }
            };

            MyMatrix m1 = new MyMatrix(matrix1);
            MyMatrix m2 = new MyMatrix(matrix2);

            MyMatrix multiplying = m1 * m2;

            bool res = true;

            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    if (result[i, j] != multiplying.GetMatrix()[i, j])
                    {
                        res = false;
                    }
                }
            }

            Assert.IsTrue(res);
        }

        [TestMethod]
        public void OperationMultiplying_ShouldThrowException()
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
                { 7, 8, 9},
                { 10,11,12}
            };

            MyMatrix m1 = new MyMatrix(matrix1);
            MyMatrix m2 = new MyMatrix(matrix2);

            var exception = Assert.ThrowsException<ArgumentException>(() =>
            {
                MyMatrix multiplying = m1 * m2;
            });

            Assert.AreEqual("Multiplying these 2 matrices is impossible due to size mismatch.", exception.Message);
        }

        [TestMethod]
        public void MethodGetTransponedCopy_ShouldWorkCorrectly()
        {
            double[,] matrix1 =
           {
                { 1, 2, 3},
                { 4, 5, 6},
                { 7, 8, 9}
            };

            MyMatrix matrix = new MyMatrix(matrix1);

            MyMatrix transposed = matrix.GetTransponedCopy();

            bool res = true;

            for (int i = 0; i < transposed.Height; i++)
            {
                for (int j = 0; j < transposed.Width; j++)
                {
                    if (transposed[i, j] != matrix1[j, i])
                    {
                        res = false;
                        break;
                    }
                }
                if (!res) break;
            }

            Assert.IsTrue(res);
        }

        [TestMethod]
        public void MethodTransponeMe_ShouldWorkCorrectly()
        {
            double[,] matrix1 =
           {
                { 1, 2, 3},
                { 4, 5, 6},
                { 7, 8, 9}
            };

            MyMatrix matrix = new MyMatrix(matrix1);

            matrix.TransponeMe();

            bool res = true;

            for (int i = 0; i < matrix.Height; i++)
            {
                for (int j = 0; j < matrix.Width; j++)
                {
                    if (matrix[i, j] != matrix1[j, i])
                    {
                        res = false;
                        break;
                    }
                }
                if (!res) break;
            }

            Assert.IsTrue(res);
        }
    }
}
