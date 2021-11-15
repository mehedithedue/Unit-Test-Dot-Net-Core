using System;
using System.Collections.Generic;

/// <summary>
///     Main Class of the program
/// </summary>
/// /// <remarks>
///     1.DO use Pascal Casing for class names and method names
///     2.DO avoid using Abbreviations.
///     3.DO use predefined type names instead of system type
///     4.DO vertically align curly brackets.
/// </remarks>
namespace UnitTestByMSTest
{
    class Program
    {
        /// <summary>
        ///     To Calculate the Average
        /// </summary>
        /// <param name="numberList"></param>
        /// <param name="includeNegetiveNumber"></param>
        /// <returns>double</returns>
        public static double Avg(List<double> numberList, bool includeNegetiveNumber)
        {
            double sum = Sum(numberList, includeNegetiveNumber);
            int count = 0;
            for (int i = 0; i < numberList.Count; i++)
            {
                if (includeNegetiveNumber || numberList[i] >= 0)
                {
                    count++;
                }
            }
            if (count == 0)
            {
                throw new ArgumentException("no values are > 0");
            }
            return sum / count;
        }

        /// <summary>
        ///     To Calculate the SUM
        /// </summary>
        /// <param name="numberList"></param>
        /// <param name="includeNegetiveNumber"></param>
        /// <returns>double</returns>
        public static double Sum(List<double> numberList, bool includeNegetiveNumber)
        {
            if (numberList.Count == 0)
            {
                throw new ArgumentException("input data cannot be empty");
            }

            double sum = 0.0;
            foreach (double val in numberList)
            {
                if (includeNegetiveNumber || val >= 0)
                {
                    sum += val;
                }
            }
            return sum;
        }
        /// <summary>
        ///     To Calculate Median of input data
        /// </summary>
        /// <param name="numberList"></param>
        /// <returns>double</returns>
        public static double Median(List<double> numberList)
        {
            int numberListCount = numberList.Count;

            if (numberListCount == 0)
            {
                throw new ArgumentException("Size of array must be greater than 0");
            }

            numberList.Sort();

            double median = numberList[numberListCount / 2];

            if (numberListCount % 2 == 0)
                median = (numberList[numberListCount / 2] + numberList[numberListCount / 2 - 1]) / 2;

            return median;
        }
        /// <summary>
        ///     To calculate Standard Deviation of input data
        /// </summary>
        /// <param name="data"></param>
        /// <returns>double</returns>
        public static double SD(List<double> data)
        {
            if (data.Count <= 1)
            {
                throw new ArgumentException("Size of array must be greater than 1");
            }

            int count = data.Count;
            double n = 0;
            double average = Avg(data, true);

            for (int i = 0; i < count; i++)
            {
                double value = data[i];
                n += Math.Pow(value - average, 2);
            }
            double stdev = Math.Sqrt(n / (count - 1));
            return stdev;
        }

        // Simple set of tests that confirm that functions operate correctly
        static void Main(string[] args)
        {
            List<Double> testData = new List<Double> { 2.2, 3.3, 66.2, 17.5, 30.2, 31.1 };

            Console.WriteLine("The sum of the array = {0}", Sum(testData, true));

            Console.WriteLine("The average of the array = {0}", Avg(testData, true));

            Console.WriteLine("The median value of the Double data set = {0}", Median(testData));

            Console.WriteLine("The sample standard deviation of the Double test set = {0}\n", SD(testData));
        }
    }
}
