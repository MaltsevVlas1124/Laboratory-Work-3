﻿using Lab_Work_3;
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
                Console.WriteLine("Некоректний вибір, спробуйте ще раз.\n");
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
                break;

            case 2:
                LavrinenkoProgram.Start();
                break;

            case 3:
                KormanProgram.cs.Start();
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
}