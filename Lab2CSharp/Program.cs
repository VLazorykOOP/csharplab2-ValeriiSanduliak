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
                    /*
                                        case "2":
                                            task3_10();
                                            break;
                    
                                        case "3":
                                            task4_10();
                                            break;
                    
                                        case "4":
                                            task5_10();
                                            break;*/
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
