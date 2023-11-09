using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task9___3
{
    internal class Program
    {
        static string DeleteWordsWithKey(string input, char key)
        {
            StringBuilder sb = new StringBuilder();
            string[] words = input.Split(' ');

            foreach (string word in words)
            {
                if(!word.ToLower().Contains(char.ToLower(key)))
                {
                    sb.Append(word + " ");
                }
            }

            return sb.ToString().Trim();
        }

        static string[] GetWords3Times(string input)
        {

        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите сообщение");
            string input = Console.ReadLine();

            Console.WriteLine("\nВведите символ");
            char key = Console.ReadLine()[0];

            string output = DeleteWordsWithKey(input, key);
            Console.WriteLine("\nОтредактированное сообщение:\n" + output);

            string[] words3times = GetWords3Times(output);

            Console.ReadLine();
        }
    }
}
