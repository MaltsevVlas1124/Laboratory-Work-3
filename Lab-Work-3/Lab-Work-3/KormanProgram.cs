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

            //Отримуємо масив з Program/arrayData, приводячи його до типу int[]
            int[] array = (int[])Program.arrayData;
            ProcessArray(ref array);
            Program.arrayData = DeletionElements(array);
            Program.ArrayStatus();
        }

        // Метод ProcessArray виводить інформацію про масив
        private static void ProcessArray(ref int[] array)
        {
            int[] myArray1 = new int[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                myArray1[i] = array[i];
            }

            // Викликаємо метод DeletionElements для видалення елементів з масиву
            int[] result1 = DeletionElements(myArray1);

            Console.WriteLine($"Кількість елементів у вихідному масиві: {myArray1.Length}");
            Console.WriteLine($"Кількість елементів у результуючому масиві: {result1.Length}\n");
        }
        // Метод DeletionElements видаляє елементи між першим мінімальним і останнім максимальним елементами в масиві
        public static int[] DeletionElements(int[] arr)
        {
            if (arr == null || arr.Length == 0)
            {
                return new int[0];
            }

            int minVal = arr.Min();
            int maxVal = arr.Max();

            int firstMinIndex = Array.IndexOf(arr, minVal);
            int lastMaxIndex = Array.LastIndexOf(arr, maxVal);

            if (firstMinIndex > lastMaxIndex)
            {
                int temp = firstMinIndex;
                firstMinIndex = lastMaxIndex;
                lastMaxIndex = temp;
            }

            // Обчислюємо розмір нового масиву
            int newSize = (firstMinIndex + 1) + (arr.Length - lastMaxIndex);
            int[] newArr = new int[newSize];
            int newArrIndex = 0;

            // Копіюємо елементи з вихідного масиву до firstMinIndex в новий масив
            for (int i = 0; i <= firstMinIndex; i++)
            {
                newArr[newArrIndex++] = arr[i];
            }

            for (int i = lastMaxIndex; i < arr.Length; i++)
            {
                newArr[newArrIndex++] = arr[i];
            }

            return newArr;
        }
        public static void DoBlock2()
        {
            Console.WriteLine("--- Завдання блоку 2, задача 6 ---\n");
            Console.WriteLine("Видалення рядків матриці, що містять хоча б один нульовий елемент.\n");

            int[][] matrix = (int[][])Program.arrayData;
            Program.arrayData = RemoveRowsContainingZero(matrix);
            Program.ArrayStatus();
        }

        // Отримуємо матрицю з Program.arrayData, приводячи її до типу int[][]
        public static int[][] RemoveRowsContainingZero(int[][] matrix)
        {
            if (matrix == null)
            {
                return new int[0][];
            }

            // Створюємо список для зберігання рядків, які не містять нульові елементи
            var result = new System.Collections.Generic.List<int[]>();

            foreach (var row in matrix)
            {
                if (row == null || row.Length == 0 || !row.Contains(0))
                {
                    result.Add(row);
                }
            }

            return result.ToArray();
        }

    }
}