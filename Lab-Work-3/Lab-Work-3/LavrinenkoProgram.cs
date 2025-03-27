using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab_Work_3
{
    class LavrinenkoProgram
    {
        public static void Start()
        {
            switch (Program.blockNum)
            {
                case 1: DoBlock_1(); break;
                case 2: DoBlock_2(); break;
            }
        }
        private static void DoBlock_1()
        {
            int[] array = (int[])Program.arrayData;
            ProcessArray(ref array);
            Program.ArrayStatus();
        }

        // Основний метод для обробки масиву
        private static void ProcessArray(ref int[] array)
        {
            // Знаходимо максимум у масиві
            int max = FindMax(array);

            // Перевіряємо, чи максимум парний
            if (max % 2 != 0)
            {
                Console.WriteLine($"Максимум {max} є непарним числом - масив залишається незмінним\n");
                return;
            }

            // Підраховуємо кількість максимумів у масиві
            int maxCount = CountValues(array, max);

            if (maxCount == 0)
            {
                Program.WriteColoredLine("Помилка: максимум не знайдено в масиві", ConsoleColor.Red);
                return;
            }

            // Створюємо новий масив з потрібним розміром
            int newSize = array.Length + maxCount;
            int[] newArray = new int[newSize];

            // Копіюємо елементи з заміною максимумів
            int newIndex = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == max)
                {
                    newArray[newIndex++] = max / 2;
                    newArray[newIndex++] = max / 2;
                }
                else
                {
                    newArray[newIndex++] = array[i];
                }
            }

            // Замінюємо основний масив новим
            Program.arrayData = newArray;
            Console.WriteLine($"Усі максимуми {max} замінено на дві {max / 2}\n");
        }


        // Метод для знаходження максимального значення в масиві
        private static int FindMax(int[] array)
        {
            int max = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
            }
            return max;
        }

        // Метод для підрахунку кількості входжень певного значення в масиві
        private static int CountValues(int[] array, int value)
        {
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == value)
                {
                    count++;
                }
            }
            return count;
        }

        
        private static void DoBlock_2()
        {
            int[][] jaggedArray = (int[][])Program.arrayData;
            ProcessEmptyRows(jaggedArray);
            Console.Clear();
            Program.ArrayStatus();
        }

        private static void ProcessEmptyRows(int[][] jaggedArray)
        {
            int k;
            while (true)
            {
                Console.WriteLine("Скільки рядків додати на початок?");
                if (!int.TryParse(Console.ReadLine(), out k))
                {
                    Console.Clear();
                    Program.WriteColoredLine("Некоректний ввід, спробуйте ще раз.\n", ConsoleColor.Red);
                    continue;
                }
                break;
            }
            int[][] newRows = new int[k][];
            for (int i = 0; i < k; i++)
            {
                Console.Clear();
                while (true)
                {
                    Console.WriteLine($"Введіть рядок {i + 1} (розділяйте числа пробілами):");
                    try
                    {
                        newRows[i] = Array.ConvertAll(Console.ReadLine().Split(" \t".ToCharArray()), int.Parse);
                        break;
                    }
                    catch
                    {
                        Console.Clear();
                        Program.WriteColoredLine("Некоректний ввід, спробуйте ще раз.\n", ConsoleColor.Red);
                        continue;
                    }
                }
            }
            // Вставляємо нові рядки на початок масиву
            int[][] result = InsertKRowsAtTop(jaggedArray, newRows);
            // Оновлюємо глобальний масив
            Program.arrayData = result;
        }

        //Метод вставки К рядків наперед 
        private static int[][] InsertKRowsAtTop(int[][] originalArray, int[][] rowsToInsert)
        {
            int originalLength = originalArray.Length;
            int rowsToInsertCount = rowsToInsert.Length;

            int[][] result = new int[originalLength + rowsToInsertCount][];

            // Спочатку додаємо нові рядки
            for (int i = 0; i < rowsToInsertCount; i++)
            {
                result[i] = rowsToInsert[i];
            }

            // Потім копіюємо оригінальні рядки
            for (int i = 0; i < originalLength; i++)
            {
                result[i + rowsToInsertCount] = originalArray[i];
            }

            return result;
        }


    }
}