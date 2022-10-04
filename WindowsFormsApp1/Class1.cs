using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    /// <summary>
    /// Класс, который содержит методы для поиска минимальных значений внутри массива.
    /// </summary>
    public class Class1
    {
        /// <summary>
        /// Метод для поиска первого минимального значения
        /// </summary>
        /// <param name="arr">Массив</param>
        /// <param name="min1">Индекс</param>
        /// <returns>Первое минимальное значение внутри массива</returns>
        public static int Min(int[] arr, out int min1)
        {
            int min2 = arr[0];
            min1 = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < min2)
                {
                    min1 = i;
                    min2 = Convert.ToInt32(arr[i]);
                }
            }
            return min2;
        }

        /// <summary>
        /// Метод для поиска второго минимального значения
        /// </summary>
        /// <param name="arr">Массив</param>
        /// <param name="min3">Индекс</param>
        /// <returns>Второе минимальное значение внутри массива</returns>
        public static int MinSecond(int[] arr, out int min3)
        {
            int min1 = 0;
            int min2 = Class1.Min(arr, out min1);
            int min4 = arr[arr.Length - 1];
            min3 = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] <= min4 && arr[i] >= min2 && i != min1)
                {
                    min3 = i;
                    min4 = Convert.ToInt32(arr[i]);
                }
            }
            return min4;
        }

        /// <summary>
        /// Метод для поиска второго минимального элемента массива, если первое минимальное значение равно последниму значению в массиве
        /// </summary>
        /// <param name="arr">Массив</param>
        /// <param name="min3">Индекс</param>
        /// <returns>Второе минимальное значение внутри массива</returns>
        public static int MinSecondHelp(int[] arr, out int min3)
        {
            if (arr.Length == 1)
                throw new ArgumentException("Массив должен состоять минимум из 2 значений!");
            int min1 = 0;
            int min2 = Class1.Min(arr, out min1);
            int min5 = arr[arr.Length - 2];
            min3 = 0;
            for (int i = arr.Length-1; i >= 0; i--)
            {
                if(arr[i] >= min2 && arr[i] <= min5 && i != min1)
                {
                    min3 = i;
                    min5 = Convert.ToInt32(arr[i]);
                }
            }
            return min5;
        }
    }
}
