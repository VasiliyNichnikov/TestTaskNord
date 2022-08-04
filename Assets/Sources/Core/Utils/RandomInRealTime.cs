using UnityEngine;

namespace Sources.Core.Utils
{
    public static class RandomInRealTime
    {
        /// <summary>
        /// Возвращает семь случайно созданных чисел на основе realtimeSinceStartup
        /// </summary>
        /// <param name="maxNumber">Максимальное число в выборке</param>
        /// <returns>Случайные числа</returns>
        public static int[] GetSevenNumber(int maxNumber)
        {
            var numbers = new int[7];
            var realtime = Time.realtimeSinceStartup;
            var realtimeInt = (int)(realtime * 10000000);

            for (var i = 1; i < 7; i++)
            {
                var division = (int)Mathf.Pow(10, i - 1);
                var remainderOfDivision = (int)Mathf.Pow(10, i);

                var number = realtimeInt % remainderOfDivision;
                if (division != 0)
                {
                    number /= division;
                }

                numbers[i - 1] = number % maxNumber;
            }
            
            return numbers;
        }
    }
}