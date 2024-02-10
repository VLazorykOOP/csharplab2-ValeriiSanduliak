using System;
using System.Drawing;

namespace Lab2CSharp
{
    public class Program
    {
        static int[] Input1DArr()
        {
            Console.WriteLine("Enter the size of the array: ");
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            for (int i = 0; i < n; ++i)
            {
                Console.WriteLine("Enter the {0} element of the array: ", i);
                arr[i] = int.Parse(Console.ReadLine());
            }
            return arr;
        }

        static int[] GenerateRandom1DArr(int length)
        {
            int[] array = new int[length];
            Random random = new Random();
            int minValue = -100;
            int maxValue = 100;
            for (int i = 0; i < length; i++)
            {
                array[i] = random.Next(minValue, maxValue + 1);
            }

            return array;
        }

        static void Prin1DtArr(int[] arr)
        {
            for (int i = 0; i < arr.Length; ++i)
                Console.Write("{0} ", arr[i]);

            Console.Write("\n");
        }

        static int[,] Input2DArray()
        {
            Console.WriteLine("Enter the number of rows: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the number of columns: ");
            int m = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, m];
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < m; ++j)
                {
                    Console.WriteLine("Enter the element of the matrix: ");
                    matrix[i, j] = int.Parse(Console.ReadLine());
                }
            }
            return matrix;
        }

        static int[,] GenerateRandom2DArray(int n, int m)
        {
            int[,] arr = new int[n, m];
            Random random = new Random();
            int minValue = -100;
            int maxValue = 100;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    arr[i, j] = random.Next(minValue, maxValue + 1);
                }
            }

            return arr;
        }

        static void Print2DArray(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); ++i)
            {
                for (int j = 0; j < arr.GetLength(1); ++j)
                    Console.Write("{0,5} ", arr[i, j]);
                Console.WriteLine();
            }
            Console.Write("\n");
        }

        static void Task1Array1D()
        {
            Console.WriteLine("Input array1D size: ");
            int n = int.Parse(Console.ReadLine());
            int[] array1D = GenerateRandom1DArr(n);
            Prin1DtArr(array1D);

            Console.WriteLine("Enter the initial value of the interval: ");
            int start = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the final value of the interval: ");
            int end = int.Parse(Console.ReadLine());

            int countOutOfRange = 0;
            foreach (var item in array1D)
            {
                if (item < start || item > end)
                {
                    countOutOfRange++;
                }
            }
            Console.WriteLine(
                $"Number of elements that do not fall within the interval [{start}, {end}]: {countOutOfRange}"
            );
        }

        static void Task1Arraay2D()
        {
            Console.WriteLine("Input array2D size rows: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Input array2D size columns: ");
            int m = int.Parse(Console.ReadLine());
            int[,] array2D = GenerateRandom2DArray(n, m);
            Print2DArray(array2D);

            Console.WriteLine("Enter the initial value of the interval: ");
            int start = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the final value of the interval: ");
            int end = int.Parse(Console.ReadLine());

            int countOutOfRange = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (array2D[i, j] < start || array2D[i, j] > end)
                    {
                        countOutOfRange++;
                    }
                }
            }

            Console.WriteLine(
                $"The number of elements of a two-dimensional array that do not fall within the interval [{start}, {end}]: {countOutOfRange}"
            );
        }

        static void Task1()
        {
            while (true)
            {
                Console.WriteLine("=========================================================");
                Console.WriteLine("Select options:");
                Console.WriteLine("1. Array1D");
                Console.WriteLine("2. Array2D");
                Console.WriteLine("3. Exit");
                Console.WriteLine("=========================================================");
                Console.Write("Enter your choice >>> ");
                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Task1Array1D();
                        break;

                    case "2":
                        Task1Arraay2D();
                        break;
                    case "3":
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }
            }
        }

        static void Task2()
        {
            Random random = new Random();
            Console.WriteLine("Input array size:");
            int size = int.Parse(Console.ReadLine());

            double[] array = new double[size];

            for (int i = 0; i < size; i++)
            {
                array[i] = random.NextDouble() * (100 - 1) + 1;
                array[i] = Math.Round(array[i], 2);
            }
            Console.WriteLine("Array:");
            for (int i = 0; i < size; i++)
            {
                Console.Write($"{array[i]} ");
            }
            double min = array[0];
            int lastIndex = 0;
            for (int i = 1; i < size; i++)
            {
                if (array[i] <= min)
                {
                    min = array[i];
                    lastIndex = i;
                }
            }
            Console.WriteLine("");
            Console.WriteLine($"The number of the last minimum element: {lastIndex + 1}");
        }

        static int[,] Pow(int[,] matrix, int exponent)
        {
            int n = matrix.GetLength(0);
            int[,] result = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                result[i, i] = 1;
            }

            for (int i = 0; i < exponent; i++)
            {
                result = Multiply(result, matrix);
            }

            return result;
        }

        static int[,] Multiply(int[,] matrix1, int[,] matrix2)
        {
            int n = matrix1.GetLength(0);
            int[,] result = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        result[i, j] += matrix1[i, k] * matrix2[k, j];
                    }
                }
            }

            return result;
        }

        static void Task3()
        {
            Console.WriteLine("Input size array2D:");
            int n = int.Parse(Console.ReadLine());

            int[,] array2D = GenerateRandom2DArray(n, n);

            Print2DArray(array2D);

            Console.WriteLine("Enter the power of n to calculate A^n:");
            int exponent = int.Parse(Console.ReadLine());

            int[,] result = Pow(array2D, exponent);

            Console.WriteLine($"The result of the calculation A^{exponent}:");
            Print2DArray(result);
        }

        static int[][] GenerateRandomStepArray(int n, int minValue, int maxValue)
        {
            int[][] array = new int[n][];
            Random random = new Random();

            for (int i = 0; i < n; i++)
            {
                array[i] = new int[i + 1];
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    array[i][j] = random.Next(minValue, maxValue + 1);
                }
            }

            return array;
        }

        static int[] CalculateSums(int[][] array, int k1, int k2)
        {
            int[] sums = new int[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = k1 - 1; j < k2 && j < array[i].Length; j++)
                {
                    sums[i] += array[i][j];
                }
            }

            return sums;
        }

        static void PrintMatrix(int[][] a)
        {
            for (int i = 0; i < a.Length; ++i, Console.WriteLine())
            for (int j = 0; j < a[i].Length; ++j)
                Console.Write("{0,5}", a[i][j]);

            Console.WriteLine();
        }

        static void Task4()
        {
            Console.WriteLine("Input row size matrix:");
            int n = int.Parse(Console.ReadLine());
            int[][] matrix = GenerateRandomStepArray(n, -100, 100);
            Console.WriteLine("Matrix:");
            PrintMatrix(matrix);

            Console.WriteLine("Input k1:");
            int k1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Input k2:");
            int k2 = int.Parse(Console.ReadLine());

            int[] sums = CalculateSums(matrix, k1, k2);
            Console.WriteLine("Sums for each row from k1 to k2:");
            foreach (var sum in sums)
            {
                Console.WriteLine(sum + " ");
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Lab 2 CSharp");

            while (true)
            {
                Console.WriteLine("=========================================================");
                Console.WriteLine("Select a task:");
                Console.WriteLine("1. Task 1");
                Console.WriteLine("2. Task 2");
                Console.WriteLine("3. Task 3");
                Console.WriteLine("4. Task 4");
                Console.WriteLine("5. Exit");
                Console.WriteLine("=========================================================");
                Console.Write("Enter your choice >>> ");
                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Task1();
                        break;

                    case "2":
                        Task2();
                        break;

                    case "3":
                        Task3();
                        break;

                    case "4":
                        Task4();
                        break;
                    case "5":
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }
            }
        }
    }
}
