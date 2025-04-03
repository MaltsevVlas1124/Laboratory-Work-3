using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Work_3
{
    class KormanProgram
    {
        public static void Start()
        {
            switch (Program.blockNum)
            {
                case 1: DoBlock1(); break;
                case 2: DoBlock2(); break;
            }
        }

        public static void DoBlock1()
        {
            Console.WriteLine("--- Завдання блоку 1, варіант 10 ---\n");
            Console.WriteLine("Видалення елементів між першим мінімальним та останнім максимальним елементами.\n");

            Program.arrayData = DeletionElements((int[])Program.arrayData);
            Program.ArrayStatus();
        }

        public static int[] DeletionElements(int[] arr)
        {
            int minVal = arr[0];
            int maxVal = arr[0];
            int firstMinIndex = 0;
            int lastMaxIndex = 0;

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] < minVal)
                {
                    minVal = arr[i];
                    firstMinIndex = i;
                }

                if (arr[i] >= maxVal)
                {
                    maxVal = arr[i];
                    lastMaxIndex = i;
                }
            }
            if (firstMinIndex > lastMaxIndex)
            {
                int temp = firstMinIndex;
                firstMinIndex = lastMaxIndex;
                lastMaxIndex = temp;
            }

            int newSize = (firstMinIndex + 1) + (arr.Length - lastMaxIndex);

            int[] newArr = new int[newSize];
            int newArrIndex = 0;

            for (int i = 0; i <= firstMinIndex; i++)
            {
                if (newArrIndex < newSize)
                {
                    newArr[newArrIndex++] = arr[i];
                }
                else break;
            }
            for (int i = lastMaxIndex; i < arr.Length; i++)
            {
                if (newArrIndex < newSize)
                {
                    newArr[newArrIndex++] = arr[i];
                }
                else break;
            }
            return newArr;
        }
        public static void DoBlock2()
        {
            Console.WriteLine("--- Завдання блоку 2, задача 6 ---\n");
            Console.WriteLine("Видалення рядків матриці, що містять хоча б один нульовий елемент.\n");

            Program.arrayData = RemoveRowsContainingZero((int[][])Program.arrayData);
            Program.ArrayStatus();

        }

        //// Отримуємо матрицю з Program.arrayData, приводячи її до типу int[][]
        //public static int[][] RemoveRowsContainingZero(int[][] jagged)
        //{
        //    if (jagged == null)
        //    {
        //        return new int[0][];
        //    }

        //    // Створюємо список для зберігання рядків, які не містять нульові елементи
        //    var result = new System.Collections.Generic.List<int[]>();

        //    foreach (var row in jagged)
        //    {
        //        if (row == null || row.Length == 0 || !row.Contains(0))
        //        {
        //            result.Add(row);
        //        }
        //    }

        //    return result.ToArray();
        //}

        public static int[][] RemoveRowsContainingZero(int[][] jagged)
        {
            int RowCount = 0;
            for (int i = 0; i < jagged.Length; i++)
            {
                int[] currentRow = jagged[i];

                if (currentRow == null || currentRow.Length == 0)
                {
                    RowCount++;
                    continue;
                }

                bool containsZero = false;
                for (int j = 0; j < currentRow.Length; j++)
                {
                    if (currentRow[j] == 0)
                    {
                        containsZero = true;
                        break;
                    }
                }


                if (!containsZero)
                {
                    RowCount++;
                }
            }

            int[][] resultMatrix = new int[RowCount][];

            int resultRowIndex = 0;
            for (int i = 0; i < jagged.Length; i++)
            {
                int[] currentRow = jagged[i];

                if (currentRow == null || currentRow.Length == 0)
                {
                    if (resultRowIndex < RowCount)
                    {
                        resultMatrix[resultRowIndex] = currentRow;
                        resultRowIndex++;
                    }
                    continue;
                }

                bool containsZero = false;
                for (int j = 0; j < currentRow.Length; j++)
                {
                    if (currentRow[j] == 0)
                    {
                        containsZero = true;
                        break;
                    }
                }

                if (!containsZero)
                {
                    if (resultRowIndex < RowCount)
                    {
                        resultMatrix[resultRowIndex] = currentRow;
                        resultRowIndex++;
                    }
                }
            }

            return resultMatrix;
        }
    }
}
