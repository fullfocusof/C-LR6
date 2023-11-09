using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
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

        static bool IsLogicSquare(int[,] array)
        {
            int sumInRow = 0, sumInCol = 0, diagSumLeft = 0, diagSumRight = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                sumInRow += array[0, i];
                sumInCol += array[i, 0];
                diagSumLeft += array[i, i];
                diagSumRight += array[i, array.GetLength(0) - 1 - i];
            }

            if(diagSumLeft != sumInRow || diagSumRight != sumInRow || sumInRow != sumInCol)
            {
                return false;
            }

            for (int i = 1; i < array.GetLength(0); i++)
            {
                int tempSumInRow = 0, tempSumInCol = 0;
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    tempSumInRow += array[i, j];
                    tempSumInCol += array[j, i];
                }
                if(tempSumInRow != sumInRow || tempSumInCol != sumInCol)
                {
                    return false;
                }
            }

            Console.WriteLine("Массив является логическим квадратом");
            return true;
        }

        static void sort(int[,] array)
        {
            int[] tempMin = new int[array.GetLength(1)];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                int minInCol = 151;
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[j, i] < minInCol)
                    {
                        minInCol = array[j, i];
                    }
                }
                tempMin[i] = minInCol;
            }

            //перестановка
        }

        static void Main(string[] args)
        {
            int[,] arr = genArr();

            Console.Clear();
            Console.WriteLine("Массив");
            printAr(arr);

            if(!IsLogicSquare(arr))
            {
                Console.WriteLine("\nМассив не является логическим квадратом\n");

                sort(arr);
                Console.WriteLine("Отсортированный массив");
                printAr(arr);
            }

            Console.ReadLine();
        }
    }
}
