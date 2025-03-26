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
            if(blockNum == 1)
            {
                Console.WriteLine(@"Оберіть тип введення масиву:

1. Заповнити вручну
2. Згенерувати випадковим чином:

   Розмір символів: від -100 до 100
   Кількість символів: від 5 до 20 

0. Повернутися до вибору блоку
");
            }
            else if (blockNum == 2) 
            {
                Console.WriteLine(@"Оберіть тип введення масиву:

1. Заповнити вручну
2. Згенерувати випадковим чином:

   Розмір символів: від -100 до 100
   Кількість рядків: від 2 до 10
   Кількість символів в одному рядку: від 5 до 20 

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
                case 1: Console.Clear(); ArrayInput(1); break;
                case 2: Console.Clear(); ArrayInput(2); break;
                case 0: Console.Clear(); BlockChoice(); break;
            }
        }
    }

    public static void ArrayInput(int inputChoice)
    {
        switch ((blockNum, inputChoice))
        {
            case (1, 1): arrayData = InputOneDimArray(); Console.Clear(); StudentChoice(); break;
            case (2, 1): arrayData = InputTwoDimArray(); Console.Clear(); StudentChoice(); break;
            case (1, 2): arrayData = GenereteOneDimArray(); Console.Clear(); StudentChoice(); break;
            case (2, 2): arrayData = GenerateTwoDimArray(); Console.Clear(); StudentChoice(); break;
        }
    }
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
    public static object GenerateTwoDimArray()
    {
        Random random = new Random();
        int rowsCount = random.Next(2, 11);
        int[][] twoDimArray = new int[rowsCount][];

        for (int i = 0; i < rowsCount; i++)
        {
            int columnsCount = random.Next(5, 21);
            twoDimArray[i] = new int[columnsCount];

            for (int j = 0; j < columnsCount; j++)
            {
                twoDimArray[i][j] = random.Next(-100, 101);
            }
        }
        return twoDimArray;
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
    public static void StudentChoice()
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
                PressAnyKeyToContinue();
                break;

            case 2:
                Console.Clear();
                //LavrinenkoProgram.Start();
                PressAnyKeyToContinue();
                break;

            case 3:
                Console.Clear();
                //KormanProgram.Start();
                PressAnyKeyToContinue();
                break;

            case 9: 
                Console.Clear(); 
                MassiveStatus(); 
                break;

            case 0:
                Console.Clear();
                Console.WriteLine("Роботу програми завершено.");
                Environment.Exit(0);
                break;

            default:
                Console.Clear();
                WriteColoredLine("Невірний вибір!", ConsoleColor.Red);
                break;
        }
    } 
    public static void MassiveStatus()
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