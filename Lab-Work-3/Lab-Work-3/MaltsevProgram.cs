﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Work_3
{
    class MaltsevProgram
    {
        public static void Start()
        {
            switch (Program.blockNum)
            {
                case 1: BlockOne(); break;
                case 2: BlockTwo(); break;
            }
        }

        public static void BlockOne()
        {
            Console.WriteLine("Одновимірний масив:\n");
            Console.WriteLine(string.Join(" ", (int[])Program.arrayData));
        }

        public static void BlockTwo()
        {
            Console.WriteLine("Двовимірний масив:'\n");
            foreach (var row in (int[][])Program.arrayData)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
