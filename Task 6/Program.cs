using System;
using System.Collections.Generic;
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
                    temp[i, j] = rand.Next(-50, 151);
                }
            }

            return temp;
        }

        static int[] GetIDofCol(int[,] arr)
        {
            int[] result = new int[0];

            for(int j = 0; j < arr.GetLength(1); j++)
            {
                int cnt = 0;
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    if (arr[i,j] < 0)
                    {
                        cnt++;
                    }
                }
                if(cnt == 2)
                {
                    Array.Resize(ref result, result.Length + 1);
                    result[result.Length - 1] = j;
                }
            }

            return result;
        }

        static void ReplaceCol(int[,] arr, int[] id)
        {
            for (int i = 0; i < id.Length; i++)
            {
                for (int j = 0; j < arr.GetLength(0); j++)
                {
                    int temp = arr[j, id[i]];
                    int curID = id[i];
                    while (curID + 1 < arr.GetLength(1))
                    {
                        arr[j, curID] = arr[j, curID + 1];
                        curID++;
                    }                   
                    arr[j, arr.GetLength(1) - 1] = temp;
                }       
            }
        }

        static void Main(string[] args)
        {
            int[,] arr = genArr();

            Console.Clear();
            Console.WriteLine("Массив");
            printAr(arr);

            int[] temp = GetIDofCol(arr);
            Console.Write("\nID столбцов с 2 отрицательными значениями: ");
            printAr(temp);

            ReplaceCol(arr, temp);
            Console.WriteLine("\n\nРезультат");
            printAr(arr);

            Console.ReadLine();
        }
    }
}
