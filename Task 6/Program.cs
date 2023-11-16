using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_6
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
        static void printAr(int[] array)
        {
            foreach (int el in array)
            {
                Console.Write(el + " ");
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
                    temp[i, j] = rand.Next(-50, 10);
                }
            }

            return temp;
        }


        static void ReplaceCol(int[,] arr)
        {
            int endPoint = arr.GetLength(1);
            for (int s = 0; s < endPoint; s++)
            {
                int cntNeg = 0;
                int colID = -1;
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    if (arr[i, s] < 0)
                    {
                        cntNeg++;
                    }
                }
                if (cntNeg == 2)
                {
                    colID = s;
                }

                if(colID != -1)
                {
                    int[] temp = new int[arr.GetLength(0)];
                    for (int i = 0; i < arr.GetLength(0); i++)
                    {
                        temp[i] = arr[i, colID];
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
                        arr[i, arr.GetLength(1) - 1] = temp[i];
                    }

                    s--;
                    endPoint--;
                }     
            } 
        }        

        static void Main(string[] args)
        {
            int[,] arr = genArr();

            Console.Clear();
            Console.WriteLine("Массив");
            printAr(arr);

            ReplaceCol(arr);
            Console.WriteLine("\n\nРезультат");
            printAr(arr);

            Console.ReadLine();
        }
    }
}
