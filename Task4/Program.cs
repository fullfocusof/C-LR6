using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
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

            int[,] temp = new int[row,col];
            int value = 1, curRow = 0, curCol = 0, direction = 1;

            for (int i = 0; i < temp.GetLength(0) * temp.GetLength(1); i++)
            {
                temp[curRow, curCol] = value;

                if((curRow == 0 && direction == -1) || ((curRow == temp.GetLength(0) - 1) && direction == 1))
                {
                    curCol++;
                    direction *= -1;
                }
                else if ((curCol == 0 && direction == 1) || ((curCol == temp.GetLength(1) - 1) && direction == -1))
                {
                    curRow++;
                    direction *= -1;
                }
                else
                {
                    curRow += direction;
                    curCol -= direction;
                }

                value++;
            }

            return temp;
        }

        static int[,] sumChange(int[,] array)
        {
            bool[,] isChecked = new bool[array.GetLength(0), array.GetLength(1)];
            int[,] result = new int[array.GetLength(0), array.GetLength(1)];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for(int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i,j] % 2 == 0 && !isChecked[i, j])
                    {
                        isChecked[i, j] = true;

                        int sum = 0;

                        if(i - 1 >= 0)
                        {
                            sum += array[i - 1, j];
                        }

                        if (i + 1 < array.GetLength(0))
                        {
                            sum += array[i + 1, j];
                        }

                        if (j - 1 >= 0)
                        {
                            sum += array[i, j - 1];
                        }

                        if (j + 1 < array.GetLength(1))
                        {
                            sum += array[i, j + 1];
                        }

                        result[i, j] = sum;
                    }
                    else
                    {
                        result[i, j] = array[i, j];
                    }
                }
            }

            return result;
        }

        static void Main(string[] args)
        {
            int[,] arr = genArr();

            Console.Clear();
            Console.WriteLine("Исходный массив: ");
            printAr(arr);

            int[,] arr2 = sumChange(arr);

            Console.WriteLine("\nРезультат: ");
            printAr(arr2);

            Console.ReadLine();
        }
    }
}
