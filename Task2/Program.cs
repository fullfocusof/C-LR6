using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Task2
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

        static int[] genArr()
        {
            Console.WriteLine("Введите целые числа через пробел, в конце нажмите Enter");
            int[] temp;
            bool isValidInput = false;

            do
            {
                string input = Console.ReadLine();
                string[] inputSplit = input.Split(' ');
                temp = new int[inputSplit.Length];

                bool isAllValidIntegers = true;
                bool isAllValidNonDec = true;

                for (int i = 0; i < inputSplit.Length; i++)
                {
                    if (!int.TryParse(inputSplit[i], out temp[i]))
                    {
                        isAllValidIntegers = false;
                        break;
                    }
                }

                for (int i = 1; i < temp.Length; i++)
                {
                    if (temp[i] < temp[i - 1])
                    {
                        isAllValidNonDec = false;
                        break;
                    }
                }

                if (isAllValidIntegers && isAllValidNonDec)
                {
                    isValidInput = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Некорректный ввод, введите целые числа через пробел, в конце нажмите Enter");
                }

            } while (!isValidInput);

            return temp;
        }

        static int[] GetIntersection(int[] ar1, int[] ar2)
        {
            int[] result = new int[0];
            int i = 0, j = 0;

            while (i < ar1.Length && j < ar2.Length)
            {
                if (ar1[i] == ar2[j])
                {
                    Array.Resize(ref result, result.Length + 1);
                    result[result.Length - 1] = ar1[i];
                    i++;
                    j++;
                }
                else if (ar1[i] < ar2[j])
                {
                    i++;
                }
                else
                {
                    j++;
                }
            }

            return result;
        }

        static void Main(string[] args)
        {
            int[] ar1 = genArr();
            int[] ar2 = genArr();

            int[] result = GetIntersection(ar1, ar2);

            Console.Clear();
            Console.Write("Первый массив: ");
            printAr(ar1);
            Console.Write("\nВторой массив: ");
            printAr(ar2);
            Console.Write("\nПересечение: ");
            printAr(result);
            Console.ReadLine();
        }
    }
}
