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
            int[] input = (int[])Program.arrayData;
            Program.arrayData = AddOneBecomePositive(input);
            Program.ArrayStatus();
        }

        private static int[] AddOneBecomePositive(int[] arr)
        {
            int positiveCount = 0;
            foreach (int x in arr)
            {
                if (x > 0)
                {
                    positiveCount++;
                }
            }
            int newSize = arr.Length + positiveCount;
            int[] newArr = new int[newSize];
            int newIndex = 0;
            foreach (int item in arr)
            {
                if (item > 0)
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
