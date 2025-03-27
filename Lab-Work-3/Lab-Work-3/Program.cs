using Lab_Work_3;
using System;
using System.Text;
using System.Threading;

class Program
{
    public static object? arrayData = null;
    public static int blockNum;
    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;
        Console.Title = "Лабораторна робота №3";
        Console.ForegroundColor = ConsoleColor.White;
        BlockChoice();
    }

    public static void BlockChoice()
    {
        while (true)
        {
            Console.WriteLine(@"Виберіть блок для виконання:

1. Блок 1 (одновимірний масив)
2. Блок 2 (двовимірний масив)

0. Вийти з програми
");
            Console.Write("Ваш вибір: ");

            if (!int.TryParse(Console.ReadLine(), out blockNum) || blockNum < 0 || blockNum > 2)
            {
                Console.Clear();
                WriteColoredLine("Некоректний вибір, спробуйте ще раз.\n", ConsoleColor.Red);
                continue;
            }

            switch (blockNum)
            {
                case 1: Console.Clear(); ArrayInputChoiceType(); break;
                case 2: Console.Clear(); ArrayInputChoiceType(); break;
                case 0: Console.Clear(); Console.WriteLine("Роботу програми завершено."); Environment.Exit(0); break;
            }
        }
    }

    public static void ArrayInputChoiceType()
    {
        while (true)
        {
            if (blockNum == 1)
            {
                Console.WriteLine(@"Оберіть тип введення масиву:

    1. Заповнити вручну (через пробіл)
    2. Згенерувати випадковим чином:

       Розмір символів: від -100 до 100
       Кількість символів: від 5 до 20 

    0. Повернутися до вибору блоку
    ");
            }
            else if (blockNum == 2)
            {
                Console.WriteLine(@"Оберіть тип введення масиву:

    1. Заповнити вручну (через пробіл)
    2. Згенерувати випадковим чином:

       Розмір символів: від -100 до 100
       Кількість рядків: від 2 до 10
       Кількість символів в одному рядку: від 0 до 20 (20% шанс створення пустого рядка)

    0. Повернутися до вибору блоку
    ");
            }

            Console.Write("Ваш вибір: ");
            if (!int.TryParse(Console.ReadLine(), out int inputChoice) || (inputChoice < 0 || inputChoice > 2))
            {
                Console.Clear();
                WriteColoredLine("Некоректний вибір, спробуйте ще раз.\n", ConsoleColor.Red);
                continue;
            }
            switch (inputChoice)
            {
                case 1: Console.Clear(); ArrayProcessing.ArrayInput(1); break;
                case 2: Console.Clear(); ArrayProcessing.ArrayInput(2); break;
                case 0: Console.Clear(); BlockChoice(); break;
            }
        }
    }

    public static void StudentChoice()
    {
        while (true)
        {
            Console.WriteLine(@"Оберіть дію:

1. Виконати варіант Мальцева Власа
2. Виконати варіант Лавріненко Олександри
3. Виконати варіант Кормана Романа

9. Вивести статус масиву

0. Повернутися до вибору типу введення
");
            Console.Write("Ваш вибір: ");

            if (!int.TryParse(Console.ReadLine(), out int choice) || ((choice < 0 || choice > 3) && choice != 9))
            {
                Console.Clear();
                WriteColoredLine("Некоректний вибір, спробуйте ще раз.\n", ConsoleColor.Red);
                continue;
            }
            ProcessChoice(choice);
        }
    }

    public static void ProcessChoice(int choice)
    {
        switch (choice)
        {
            case 1:
                Console.Clear();
                MaltsevProgram.Start();
                break;

            case 2:
                Console.Clear();
                LavrinenkoProgram.Start();
                break;

            case 3:
                Console.Clear();
                KormanProgram.Start();
                break;

            case 9:
                Console.Clear();
                ArrayStatus();
                break;

            case 0:
                Console.Clear();
                ArrayInputChoiceType();
                break;


            default: // Рудимент коду. Залишено "про всяк випадок"
                Console.Clear();
                WriteColoredLine("Невірний вибір!", ConsoleColor.Red);
                break;
        }
    }

    public static void ArrayStatus()
    {
        switch (blockNum)
        {
            case 1:
                Console.WriteLine("Вигляд одновимірного масиву:\n");
                Console.WriteLine(string.Join(" ", (int[])Program.arrayData));
                PressAnyKeyToContinue();
                break;

            case 2:
                int i = 1;
                Console.WriteLine("Вигляд двовимірного масиву:\n");
                foreach (var row in (int[][])Program.arrayData ?? Array.Empty<int[]>())
                {
                    Console.Write($"{i++}) ");
                    if (row == null || row.Length == 0)
                    {
                        Console.WriteLine("Пустий рядок");
                    }
                    else
                    {
                        Console.WriteLine(string.Join(" ", row));
                    }
                }
                PressAnyKeyToContinue();
                break;

            default: // Рудимент коду. Залишено "про всяк випадок"
                WriteColoredLine("Невірний вибір!", ConsoleColor.Red);
                PressAnyKeyToContinue();
                break;
        }
    }

    // Методи для виведення тексту в консоль певним кольором
    public static void WriteColored(string text, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.Write(text);
        Console.ForegroundColor = ConsoleColor.White;
    }

    public static void WriteColoredLine(string text, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(text);
        Console.ForegroundColor = ConsoleColor.White;
    }

    // Метод для очікування натискання будь-якої клавіші (як називається те й робить)
    public static void PressAnyKeyToContinue()
    {
        Console.Write("\nНатисніть будь-яку клавішу, щоб продовжити...");
        Console.ReadKey(true);
        Console.Clear();
    }
}