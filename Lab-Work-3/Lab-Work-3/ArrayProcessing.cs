using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Work_3
{
    class ArrayProcessing
    {
        // Метод обробки вибору типу введення масиву
        public static void ArrayInput(int inputChoice)
        {
            switch ((Program.blockNum, inputChoice))
            {
                case (1, 1): Program.arrayData = InputOneDimArray(); Console.Clear(); Program.StudentChoice(); break;
                case (2, 1): Program.arrayData = InputTwoDimArray(); Console.Clear(); Program.StudentChoice(); break;
                case (1, 2): Program.arrayData = GenereteOneDimArray(); Console.Clear(); Program.ArrayStatus(); Program.StudentChoice(); break;
                case (2, 2): Program.arrayData = GenerateTwoDimArray(); Console.Clear(); Program.ArrayStatus(); Program.StudentChoice(); break;
            }   
        }
        // Метод генерації одновимірного масиву
        public static object GenereteOneDimArray()
        {
            Random random = new Random();
            int elementsCount = random.Next(5, 21);
            int[] oneDimArray = new int[elementsCount];
            for (int i = 0; i < elementsCount; i++)
            {
                oneDimArray[i] = random.Next(-100, 101);
            }
            return oneDimArray;
        }
        // Метод генерації двовимірного масиву
        public static object GenerateTwoDimArray()
        {
            Random random = new Random();
            int rowsCount = random.Next(2, 11);
            int[][] twoDimArray = new int[rowsCount][];

            for (int i = 0; i < rowsCount; i++)
            {
                // 20% шанс створення порожнього рядка
                if (random.Next(0, 100) < 20)
                {
                    twoDimArray[i] = null;
                    continue;
                }

                int columnsCount = random.Next(5, 21);
                twoDimArray[i] = new int[columnsCount];

                for (int j = 0; j < columnsCount; j++)
                {
                    twoDimArray[i][j] = random.Next(-100, 101);
                }
            }
            return twoDimArray;
        }
        // Метод введення одновимірного масиву
        static int[] InputOneDimArray()
        {
            int[] oneDimArray;
            while (true)
            {
                Console.Write("Введіть масив через пробіл: ");
                string input = Console.ReadLine();
                if (input == null)
                {
                    Console.Clear();
                    Program.WriteColoredLine("Масив пустий, обробка неможлива. Спробуйте ще раз.\n", ConsoleColor.Red);
                    continue;
                }
                try
                {
                    oneDimArray = input.Split(' ').Select(int.Parse).ToArray();
                    break;
                }
                catch
                {
                    Console.Clear();
                    Program.WriteColoredLine("Некоректний ввід, спробуйте ще раз.\n", ConsoleColor.Red);
                }
            }
            return oneDimArray;
        }
        // Метод введення двовимірного масиву
        static int[][] InputTwoDimArray()
        {
            Console.Write("Введіть кількість рядків у масиві: ");
            if (!int.TryParse(Console.ReadLine(), out int rowsCount) || rowsCount < 0)
            {
                Console.Clear();
                Program.WriteColoredLine("Некоректний ввід, спробуйте ще раз.\n", ConsoleColor.Red);
                return InputTwoDimArray();
            }

            int[][] twoDimArray = new int[rowsCount][];
            for (int i = 0; i < rowsCount; i++)
            {
                Console.WriteLine($"\nВведіть елементи для рядка {i + 1} через пробіл:");
                string input = Console.ReadLine();
                try
                {
                    twoDimArray[i] = Array.ConvertAll(input.Split(" \t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries), int.Parse);
                }
                catch
                {
                    Console.Clear();
                    Program.WriteColoredLine("Некоректний ввід, спробуйте ще раз.\n", ConsoleColor.Red);
                    i--;
                }
            }
            return twoDimArray;
        }
    }
}
