using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    internal class Program
    {
        static void printAr(int[] array)
        {
            foreach (int el in array)
            {
                Console.Write(el + " ");
            }
        }

        static void printAr(int[] array, int n)
        {
            if (array.Length >= n && n >= 0)
            {
                for (int i = 0; i < n; i++)
                {
                    Console.Write(array[i] + " ");
                }
            }
        }

        static int[] genArr()
        {
            Console.WriteLine("Введите размер массива");
            int size = 0;
            bool isValid = false;

            do
            {
                string input = Console.ReadLine();

                if (int.TryParse(input, out size) && size > 0)
                {
                    isValid = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Некорректный ввод, введите размер массива");
                }

            } while (!isValid);

            int[] temp = new int[size];
            Random rand = new Random();
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = rand.Next(-15, 31);
            }

            return temp;
        }

        static void ArrayErase(ref int[] ar, int ID)
        {
            for(int i = ID; i < ar.Length - 1; i++)
            {
                ar[i] = ar[i + 1];
            }

            Array.Resize(ref ar, ar.Length - 1);
        }

        static void ArrayInsertBefore(ref int[] ar, int value, int ID)
        {
            Array.Resize(ref ar, ar.Length + 1);

            for (int i = ar.Length - 2; i >= ID; i--)
            {
                ar[i + 1] = ar[i];
            }

            ar[ID] = value;
        }

        static void Main(string[] args)
        {
            int[] arr = genArr();
            int minEl = arr.Min();
            Console.Clear();
            Console.Write("Исходный массив: ");
            printAr(arr);

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == arr.Max())
                {
                    ArrayInsertBefore(ref arr, minEl, i);
                    i++;
                }
            }

            Console.Write("\nВставка перед максимальными: ");
            printAr (arr);

            for (int i = 0; i < arr.Length; i++)
            {       
                for (int j = 0; j < arr.Length; j++)
                {
                    if (arr[i] == arr[j] && i != Array.IndexOf(arr, arr[i]))
                    {
                        ArrayErase(ref arr, i);
                    }
                }
            }

            Console.Write("\nУдаление дубликатов: ");
            printAr(arr);
            Console.ReadLine();
        }
    }
}
