using Lab_Work_3;
using System;
using System.Text;
using System.Threading;

class Program
{
    public static object arrayData = null;
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

            if (!int.TryParse(Console.ReadLine(), out int blockNum) || blockNum < 0 || blockNum > 2)
            {
                Console.Clear();
                WriteColoredLine("Некоректний вибір, спробуйте ще раз.\n", ConsoleColor.Red);
                continue;
            }

            switch (blockNum)
            {
                case 1: Console.Clear(); ArrayInput(blockNum); break;
                case 2: Console.Clear(); ArrayInput(blockNum); break;
                case 0: Console.Clear(); Console.WriteLine("Роботу програми завершено."); Environment.Exit(0); break;
            }
        }
    }
    public static void ArrayInput(int blockNum)
    {
        switch (blockNum)
        {
            case 1: arrayData = InputOneDimArray(); Console.Clear(); StudentChoice(blockNum); break;
            case 2: arrayData = InputTwoDimArray(); Console.Clear(); StudentChoice(blockNum); break;
        }
    }
    static int[] InputOneDimArray()
    {
        int[] oneDimArray;
        while (true)
        {
            Console.Write("Введіть масив через пробіл: ");
            string input = Console.ReadLine();
            try
            {
                oneDimArray = input.Split(' ').Select(int.Parse).ToArray();
                break;
            }
            catch
            {
                Console.Clear();
                WriteColoredLine("Некоректний ввід, спробуйте ще раз.\n", ConsoleColor.Red);
            }
        }
        return oneDimArray;
    }
    static int[][] InputTwoDimArray()
    {
        Console.Write("Введіть кількість рядків у масиві: ");
        if (!int.TryParse(Console.ReadLine(), out int rowsCount))
        {
            WriteColoredLine("Некоректний ввід, спробуйте ще раз.\n", ConsoleColor.Red);
            return InputTwoDimArray();
        }

        int[][] twoDimArray = new int[rowsCount][];
        for (int i = 0; i < rowsCount; i++)
        {
            Console.WriteLine($"\nВведіть елементи для рядка {i + 1} через пробіл:");
            string input = Console.ReadLine();
            if (input == null)
            {
                WriteColoredLine("Некоректний ввід, спробуйте ще раз.\n", ConsoleColor.Red);
                i--;
                continue;
            }

            try
            {
                twoDimArray[i] = Array.ConvertAll(input.Split(" \t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries), int.Parse);
            }
            catch
            {
                WriteColoredLine("Некоректний ввід, спробуйте ще раз.\n", ConsoleColor.Red);
                i--;
            }
        }
        return twoDimArray;
    }
    public static void StudentChoice(int blockNum)
    {
            while (true)
        {
            Console.WriteLine(@"Оберіть дію:

1. Виконати файл Мальцева Власа
2. Виконати файл Лавріненко Олександри
3. Виконати файл Кормана Романа

9. Вивести статус масиву

0. Повернутися до вибору блоку
");
            Console.Write("Ваш вибір: ");

            if (!int.TryParse(Console.ReadLine(), out int choice) || ((choice < 0 || choice > 3) && choice != 9))
            {
                Console.Clear();
                WriteColoredLine("Некоректний вибір, спробуйте ще раз.\n", ConsoleColor.Red);
                continue;
            }
            ProcessChoice(choice, blockNum);
        }
    }

    public static void ProcessChoice(int choice, int blockNum)
    {
        switch (choice)
        {
            case 1:
                Console.Clear();
                MaltsevProgram.Start(blockNum);
                PressAnyKeyToContinue();
                break;

            case 2:
                Console.Clear();
                LavrinenkoProgram.Start(blockNum);
                PressAnyKeyToContinue();
                break;

            case 3:
                Console.Clear();
                KormanProgram.Start(blockNum);
                PressAnyKeyToContinue();
                break;

            case 9: 
                Console.Clear(); 
                MassiveStatus(blockNum); 
                break;

            case 0:
                Console.Clear();
                Console.WriteLine("Роботу програми завершено.");
                Environment.Exit(0);
                break;

            default:
                Console.Clear();
                Console.WriteLine("Невірний вибір!");
                break;
        }
    }
   
    public static void MassiveStatus(int blockNum)
    {
        if (blockNum == 1)
        {    
            Console.WriteLine("Вигляд одновимірного масиву:\n");
            Console.WriteLine(string.Join(" ", (int[])Program.arrayData));
            PressAnyKeyToContinue();
        }
        else if (blockNum == 2)
        {
            Console.WriteLine("Вигляд двовимірного масиву:\n");
            foreach (var row in (int[][])Program.arrayData)
            {
                Console.WriteLine(string.Join(" ", row));
            }
            PressAnyKeyToContinue();
        }
        else
        {
            WriteColoredLine("Невірний вибір!", ConsoleColor.Red);
            PressAnyKeyToContinue();
        }
    }
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

    public static void PressAnyKeyToContinue()
    {
        Console.WriteLine("\nНатисніть будь-яку клавішу, щоб продовжити...");
        Console.ReadKey(true);
        Console.Clear();
    }
}