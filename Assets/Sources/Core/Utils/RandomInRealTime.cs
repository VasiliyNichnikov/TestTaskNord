using UnityEngine;

namespace Sources.Core.Utils
{
    public static class RandomInRealTime
    {
        /// <summary>
        /// Возвращает случайное число на основе realtimeSinceStartup
        /// </summary>
        /// <param name="maxNumber">Максимальное значение числа</param>
        /// <returns>Случайное число</returns>
        public static int GetNumber(int maxNumber)
        {
            var realtimeInt = GetRealtimeInt();
            var number = GetDigitOfNumber(realtimeInt, 1);
            return number % maxNumber;
        }
        
        /// <summary>
        /// Возвращает семь случайно созданных чисел на основе realtimeSinceStartup
        /// </summary>
        /// <param name="maxNumber">Максимальное число в выборке</param>
        /// <returns>Случайные числа</returns>
        public static int[] GetSevenNumber(int maxNumber)
        {
            var numbers = new int[7];
            var realtimeInt = GetRealtimeInt();

            for (var i = 1; i < 7; i++)
            {
                // var division = (int)Mathf.Pow(10, i - 1);
                // var remainderOfDivision = (int)Mathf.Pow(10, i);
                //
                // var number = realtimeInt % remainderOfDivision;
                // if (division != 0)
                // {
                //     number /= division;
                // }
                var number = GetDigitOfNumber(realtimeInt, i);
                
                numbers[i - 1] = number % maxNumber;
            }
            
            return numbers;
        }

        private static int GetDigitOfNumber(int number, int dischargeNumber)
        {
            var division = (int)Mathf.Pow(10, dischargeNumber - 1);
            var remainderOfDivision = (int)Mathf.Pow(10, dischargeNumber);

            var result = number % remainderOfDivision;
            if (division != 0)
                result /= division;
            return result;
        }
        
        private static int GetRealtimeInt()
        {
            var realtime = Time.realtimeSinceStartup;
            var realtimeInt = (int)(realtime * 10000000);
            return realtimeInt;
        }
    }
}