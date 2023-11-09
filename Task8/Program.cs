using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Task8
{
    internal class Program
    {
        static int FindCntSymb(string str, char symbol)
        {
            int count = 0;

            foreach (char c in str)
            {
                if(c == symbol)
                {
                    count++;
                }
            }

            return count;
        }

        static int UniqueSymb(string str)
        {
            int count = 0;
            bool[] isChecked = new bool[256];

            foreach (char c in str)
            {
                if (!isChecked[c])
                {
                    isChecked[c] = true;
                    count++;
                }
            }

            return count;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку");
            string input = Console.ReadLine();

            Console.WriteLine("\nВведите два искомых символа через пробел и нажмите Enter");
            string inputSymb = Console.ReadLine();
            char first = inputSymb[0];
            char second = inputSymb[2];

            while (first == ' ' || second == ' ')
            {
                Console.Clear();
                Console.WriteLine("Введите верные символы");
                inputSymb = Console.ReadLine();
                first = inputSymb[0];
                second = inputSymb[2];
            }

            int cntFirst = FindCntSymb(input, first);
            int cntSecond = FindCntSymb(input, second);

            Console.Clear();
            Console.WriteLine("Строка - " + input);
            Console.WriteLine("\nКоличество символов " + first + " - " + cntFirst);
            Console.WriteLine("Количество символов " + second + " - " + cntSecond);

            if (cntFirst == cntSecond)
            {
                Console.WriteLine("\nКоличество уникальных символов - " + UniqueSymb(input));
            }
            else
            {
                char result = Math.Max(cntFirst, cntSecond) == cntFirst ? first : second;
                Console.WriteLine("\nНаиболее часто встречающийся символ - " + result);
            }

            Console.ReadLine();
        }
    }
}
