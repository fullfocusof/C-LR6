using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task9
{
    internal class Program
    {
        static int SumInStr(string input)
        {
            int sum = 0;
            string curNum = "";
            bool isNegative = false;

            foreach (char c in input)
            {
                if(char.IsDigit(c))
                {
                    curNum += c;
                }
                else if(curNum.Length > 0)
                {
                    if(int.TryParse(curNum, out int num))
                    {
                        sum += isNegative ? -num : num;
                        isNegative = false;
                    }
                    curNum = "";
                }
                else if (c == '-')
                {
                    isNegative = true;
                }
                else
                {
                    isNegative = false;
                }
            }

            if (curNum.Length > 0)
            {
                if (int.TryParse(curNum, out int num))
                {
                    sum += isNegative ? -num : num;
                }
            }

            return sum;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку");
            string input = Console.ReadLine();

            Console.WriteLine("\nСумма чисел в строке - " + SumInStr(input));
            Console.ReadLine();
        }
    }
}
