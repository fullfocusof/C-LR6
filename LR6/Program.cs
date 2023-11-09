using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR6
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

                for (int i = 0; i < inputSplit.Length; i++)
                {
                    if (!int.TryParse(inputSplit[i], out temp[i]))
                    {
                        isAllValidIntegers = false;
                        break;
                    }
                }

                if (isAllValidIntegers)
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

        static void Main(string[] args)
        {            
            int[] ints = genArr();
            int firstMaxID = Array.IndexOf(ints, ints.Max()), lastMinID = Array.LastIndexOf(ints, ints.Min());
     
            Console.Clear();
            Console.Write("Исходный массив: ");
            printAr(ints);

            if(firstMaxID < lastMinID)
            {
                Array.Reverse(ints, firstMaxID + 1, lastMinID - firstMaxID - 1);
            }
            else
            {
                Array.Reverse(ints, lastMinID + 1, firstMaxID - lastMinID - 1);
            }

            Console.Write("\n\nРезультат: ");
            printAr(ints);
            Console.ReadLine();
        }
    }
}
