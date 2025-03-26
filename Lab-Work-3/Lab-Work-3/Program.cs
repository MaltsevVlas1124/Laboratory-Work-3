using Lab_Work_3;
using System;
using System.Text;
using System.Threading;

class Program
{
    public static void Main()
    {
        while (true)
        {
            Console.WriteLine(@"Оберіть дію:

1. Виконати файл Мальцева Власа
2. Виконати файл Лавріненко Олександри
3. Виконати файл Кормана Романа

0. Вийти
");
            Console.Write("Ваш вибір: ");


            if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 0 || choice > 3)
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
                MaltsevProgram.Start();
                PressAnyKeyToContinue();
                break;

            case 2:
                LavrinenkoProgram.Start();
                PressAnyKeyToContinue();
                break;

            case 3:
                KormanProgram.Start();
                PressAnyKeyToContinue();
                break;

            case 0:
                Console.WriteLine("\nРоботу програми завершено.");
                Environment.Exit(0);
                break;

            default:
                Console.WriteLine("Невірний вибір!");
                break;

        }
    }

    private static void WriteColored(string text, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.Write(text);
        Console.ForegroundColor = ConsoleColor.Cyan;
    }

    private static void WriteColoredLine(string text, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(text);
        Console.ForegroundColor = ConsoleColor.Cyan;
    }

    public static void PressAnyKeyToContinue()
    {
        Console.WriteLine("\nНатисніть будь-яку клавішу, щоб продовжити...");
        Console.ReadKey(true);
        Console.Clear();
    }

}