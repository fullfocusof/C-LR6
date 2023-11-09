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

        static int[,] EraseMin(ref int[,] arr, int rowID, int colID)
        {
            int[,] result = new int[arr.GetLength(0) - 1, arr.GetLength(1) - 1];
            int newRowID = 0, newColID;

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                if (i == rowID)
                    continue;

                newColID = 0;

                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (j == colID)
                        continue;

                    result[newRowID, newColID] = arr[i, j];
                    newColID++;
                }
                newRowID++;
            }

            return result;
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

        static int[,] AddZero(int[,] arr, int rows, int cols, int choice)
        {
            int[,] result = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if(choice == 1)
                    {
                        if (i == rows / 2)
                        {
                            result[i, j] = 0;
                        }
                        else if (j == cols / 2)
                        {
                            result[i, j] = 0;
                        }
                        else
                        {
                            result[i, j] = (i < rows / 2 && j < cols / 2) ? arr[i, j] : (i < rows / 2) ? arr[i, j - 1] : (j < cols / 2) ? arr[i - 1, j] : arr[i - 1, j - 1];
                        }
                    }
                    else if(choice == 2)
                    {
                        if (i == rows / 2)
                        {
                            result[i, j] = 0;
                        }
                        else
                        {
                            result[i, j] = i < rows / 2 ? arr[i, j] : arr[i - 1, j];
                        }
                    }
                    else
                    {
                        if (j == cols / 2)
                        {
                            result[i, j] = 0;
                        }
                        else
                        {
                            result[i, j] = j < cols / 2 ? arr[i, j] : arr[i, j - 1];
                        }
                    }
                }
            }

            return result;
        }

        static void Main(string[] args)
        {
            int[,] arr = genArr();

            Console.Clear();
            Console.WriteLine("Массив");
            printAr(arr);

            (int, int) ID = FindMinElID(arr);
            int[,] temp = EraseMin(ref arr, ID.Item1, ID.Item2);

            Console.WriteLine("\nСокращенный массив");
            printAr(temp);

            int[,] res = new int[0, 0];

            if (temp.GetLength(0) % 2 == 0 && temp.GetLength(1) % 2 == 0)
            {
                res = AddZero(temp, temp.GetLength(0) + 1, temp.GetLength(1) + 1, 1);
            }
            else if (temp.GetLength(0) % 2 == 0)
            {
                res = AddZero(temp, temp.GetLength(0) + 1, temp.GetLength(1), 2);
            }
            else if (temp.GetLength(1) % 2 == 0)
            {
                res = AddZero(temp, temp.GetLength(0), temp.GetLength(1) + 1, 3);
            }
            else
            {
                res = temp;
            }

            Console.WriteLine("\nРезультат");
            printAr(res);

            Console.ReadLine();
        }
    }
}
