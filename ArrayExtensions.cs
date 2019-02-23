using System;
using System.Globalization;

namespace PadawansTask11
{
    public static class ArrayExtensions
    {
        public static int? FindIndex(double[] array, double accuracy)
        {
            if (array == null) throw new ArgumentNullException();
            if (array.Length < 3) throw new ArgumentException();
            if (accuracy <= 0 || accuracy >= 1) throw new ArgumentOutOfRangeException();
            if (accuracy < 5.0E-324d) accuracy = 0;
            double[] leftsum = new double[array.Length];
            double[] rightsum = new double[array.Length];
            leftsum[0] = array[0];
            rightsum[array.Length - 1] = array[array.Length - 1];
            for (int i = 1; i < array.Length; i++)
            {
                leftsum[i] = leftsum[i - 1] + array[i];
                rightsum[array.Length - i - 1] = rightsum[array.Length - i] + array[array.Length - i -1];
            }

            for (int i = 1; i < leftsum.Length - 1; i++)
                if (Math.Abs(leftsum[i - 1] - rightsum[i + 1]) <= accuracy)
                    return i;
            return null;
        }
    }
}
