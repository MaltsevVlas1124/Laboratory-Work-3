using System;
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
        private static void BlockOne()
        {
            Console.WriteLine("--- Завдання блоку 1, варіант 16 ---\n");
            Console.WriteLine("Додавання '1' перед кожним парним елементом.\n");

            int[] input = (int[])Program.arrayData;
            Program.arrayData = AddOneBeforeEven(input);
            Program.ArrayStatus();
        }

        private static int[] AddOneBeforeEven(int[] arr)
        {
            int evenCount = 0;
            foreach (int x in arr)
            {
                if (x % 2 == 0)
                {
                    evenCount++;
                }
            }
            int newSize = arr.Length + evenCount;
            int[] newArr = new int[newSize];
            int newIndex = 0;
            foreach (int item in arr)
            {
                if (item % 2 == 0)
                {
                    newArr[newIndex] = 1;
                    newIndex++;
                }
                newArr[newIndex] = item;
                newIndex++;
            }
            return newArr;
        }
        private static void BlockTwo()
        {
            Console.WriteLine("--- Завдання блоку 2, варіант 7 ---\n");
            Console.WriteLine("Знищування всіх порожніх рядків\n");

            int[][] matrix = (int[][])Program.arrayData;
            Program.arrayData = RemoveEmptyRows(matrix);
            Program.ArrayStatus();
        }
        private static int[][] RemoveEmptyRows(int[][] matrix)
        {
            return matrix.Where(row => row != null && row.Length > 0).ToArray();
        }

        //public static int[][] RemoveEmptyRows(int[][] matrix)
        //{
        //    List<int[]> result = new List<int[]>();
        //    foreach (int[] row in matrix)
        //    {
        //        if (row != null && row.Length > 0)
        //        {
        //            result.Add(row);
        //        }
        //    }
        //    return result.ToArray();
        //}
    }
}
