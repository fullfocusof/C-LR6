using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7
{
    internal class Program
    {
        static void printAr(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        static void printAr(int[,] array, int limitRow, int limitCol)
        {
            if (array.GetLength(0) >= limitRow && array.GetLength(1) >= limitCol && limitRow >= 0 && limitCol >= 0)
            {
                for (int i = 0; i < limitRow; i++)
                {
                    for (int j = 0; j < limitCol; j++)
                    {
                        Console.Write(array[i, j] + "\t");
                    }
                    Console.WriteLine();
                }
            }
        }

        static int[,] genArr()
        {
            Console.WriteLine("Введите размеры массива через пробел, в конце нажмите Enter");
            int row = 0, col = 0;
            bool isValid = false;

            do
            {
                string input = Console.ReadLine();
                string[] inputSplit = input.Split(' ');

                if (int.TryParse(inputSplit[0], out row) && row > 0 && int.TryParse(inputSplit[1], out col) && col > 0)
                {
                    isValid = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Некорректный ввод, введите размеры массива через пробел, в конце нажмите Enter");
                }

            } while (!isValid);

            int[,] temp = new int[row, col];
            Random rand = new Random();
            for (int i = 0; i < temp.GetLength(0); i++)
            {
                for (int j = 0; j < temp.GetLength(1); j++)
                {
                    temp[i, j] = rand.Next(-50, 151);
                }
            }

            return temp;
        }

        static void EraseMin(int[,] arr, int rowID, int colID)
        {
            int[] tempRow = new int[arr.GetLength(1)];
            int[] tempCol = new int[arr.GetLength(0)];
            for (int i = 0; i < tempRow.Length; i++)
            {
                tempRow[i] = arr[rowID, i];
            }
            for (int i = 0; i < tempCol.Length; i++)
            {
                tempCol[i] = arr[i, colID];
            }

            for (int i = rowID + 1; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i - 1, j] = arr[i, j];
                }
            }
            for (int i = 0; i < arr.GetLength(1); i++)
            {
                arr[arr.GetLength(0) - 1, i] = tempRow[i];
            }

            for (int i = colID + 1; i < arr.GetLength(1); i++)
            {
                for (int j = 0; j < arr.GetLength(0); j++)
                {
                    arr[j, i - 1] = arr[j, i];
                }
            }
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                arr[i, arr.GetLength(1) - 1] = tempCol[i];
            }
        }

        static (int,int) FindMinElID(int[,] arr)
        {
            int min = arr[0, 0];
            (int, int) minID = (0, 0);

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] < min)
                    {
                        min = arr[i, j];
                        minID = (i, j);
                    }
                }
            }

            return minID;
        }

        static void AddZero(int[,] arr)
        {
            int rowID = -1, colID = -1;
            if ((arr.GetLength(0) - 1) % 2 == 0 && (arr.GetLength(1) - 1) % 2 == 0)
            {
                rowID = (arr.GetLength(0) - 1) / 2;
                colID = (arr.GetLength(1) - 1) / 2;

                for (int i = arr.GetLength(1) - 1; i > colID; i--)
                {
                    for (int j = 0; j < arr.GetLength(0); j++)
                    {
                        arr[j, i] = arr[j, i - 1];
                    }
                }

                for(int i = arr.GetLength(0) - 1; i > rowID; i--)
                {
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        arr[i, j] = arr[i - 1, j];
                    }
                }

                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    arr[i, colID] = 0;
                }
                for (int i = 0; i < arr.GetLength(1); i++)
                {
                    arr[rowID, i] = 0;
                }

            }
            else if ((arr.GetLength(0) - 1) % 2 == 0)
            {
                rowID = (arr.GetLength(0) - 1) / 2;

                for (int i = arr.GetLength(0) - 1; i > rowID; i--)
                {
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        arr[i, j] = arr[i - 1, j];
                    }
                }

                for (int i = 0; i < arr.GetLength(1); i++)
                {
                    arr[rowID, i] = 0;
                }
            }
            else if ((arr.GetLength(1) - 1) % 2 == 0)
            {
                colID = (arr.GetLength(1) - 1) / 2;

                for (int i = arr.GetLength(1) - 1; i > colID; i--)
                {
                    for (int j = 0; j < arr.GetLength(0); j++)
                    {
                        arr[j, i] = arr[j, i - 1];
                    }
                }

                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    arr[i, colID] = 0;
                }
            }
        }

        static void Main(string[] args)
        {
            int[,] arr = genArr();
            Console.Clear();
            Console.WriteLine("Массив");
            printAr(arr);

            (int, int) ID = FindMinElID(arr);
            EraseMin(arr, ID.Item1, ID.Item2);
            Console.WriteLine("\nСокращенный массив");
            printAr(arr);

            AddZero(arr);
            Console.WriteLine("\nРезультат");
            printAr(arr);

            Console.ReadLine();
        }
    }
}
