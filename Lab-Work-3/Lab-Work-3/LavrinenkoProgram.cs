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
            Console.WriteLine("--- Завдання блоку 1, варіант 13 ---\n");
            Console.WriteLine("Заміна кожного максимума (якщо парний) двома їхніми половинами\n");

            Program.arrayData = ProcessArray((int[])Program.arrayData);
            Program.ArrayStatus();
        }

        // Основний метод для обробки масиву
        private static int[] ProcessArray(int[] array)
        {
            // Знаходимо максимум у масиві
            int max = FindMax(array);

            if (max % 2 != 0)
            {
                Console.WriteLine($"Максимум {max} є непарним числом - масив залишається незмінним\n");
                return array;
            }

            // Підраховуємо кількість максимумів у масиві
            int maxCount = CountValues(array, max);

            if (maxCount == 0)
            {
                Program.WriteColoredLine("Помилка: максимум не знайдено в масиві", ConsoleColor.Red);
                return array;
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

            Console.WriteLine($"Усі максимуми {max} замінено на дві {max / 2}\n");
            return newArray;
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
            Console.WriteLine("--- Завдання блоку 2, задача 2 ---\n");
            Console.WriteLine("Додавання К рядків у початок (угору) зубчастого масиву.\n");

            
            Program.arrayData = ProcessCreatingNewRows((int[][])Program.arrayData);
            Console.Clear();
            Program.ArrayStatus();

        }

        //метод додає нові рядки у початок зубчастого масиву
        private static int[][] ProcessCreatingNewRows(int[][] jaggedArray)
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
            Console.Clear();
            while (true)
            {
                Console.WriteLine(@"Чи бажаєте заповнити нові рядки?

1. Так
2. Ні
            ");
                Console.Write("Ваш вибір: ");
                if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > 2)
                {
                    Console.Clear();
                    Program.WriteColoredLine("Некоректний вибір, спробуйте ще раз.\n", ConsoleColor.Red);
                    continue;
                }
                switch (choice)
                {
                    case 1:
                        FillNewRows(k, newRows);
                        return InsertKRowsAtTop(jaggedArray, newRows);
                    case 2: return InsertKRowsAtTop(jaggedArray, newRows);
                }
            }
        }

        private static void FillNewRows(int k, int[][] newRows)
        {
            for (int i = 0; i < k; i++)
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine($"Введіть рядок {i + 1} (розділяйте числа пробілами):");
                    try
                    {
                        string input = Console.ReadLine();
                                                                                         //порожні значення буде видалено
                        newRows[i] = Array.ConvertAll(input.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries), int.Parse);
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
        }

        //Метод вставки К рядків наперед 
        private static int[][] InsertKRowsAtTop(int[][] jaggedArray, int[][] newRows)
        {
            int originalLength = jaggedArray.Length;
            int rowsToInsertCount = newRows.Length;

            int[][] result = new int[originalLength + rowsToInsertCount][];

            // Спочатку додаємо нові рядки
            for (int i = 0; i < rowsToInsertCount; i++)
            {
                result[i] = newRows[i];
            }

            // Потім копіюємо оригінальні рядки
            for (int i = 0; i < originalLength; i++)
            {
                result[i + rowsToInsertCount] = jaggedArray[i];
            }

            return result;
        }


    }
}
