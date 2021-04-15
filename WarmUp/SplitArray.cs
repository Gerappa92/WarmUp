using System.Collections.Generic;

namespace WarmUp
{
    public class SplitArray
    {
        public (long[], long[]) SplitToEvenAndOdd(long[] array)
        {
            List<long> even = new List<long>();
            List<long> odd = new List<long>();

            for (int i = 0; i < array.Length; i++)
            {
                if(array[i]%2 == 0)
                {
                    even.Add(array[i]);
                }
                else if(array[i]%2 == 1)
                {
                    odd.Add(array[i]);
                }
            }

            return (even.ToArray(), odd.ToArray());

        }

        public (long[], long[]) SplitOnHalfs(long[] array)
        {
            List<long> left = new List<long>();
            List<long> right = new List<long>();

            var halfIndex = (array.Length / 2) + array.Length%2;

            for (int i = 0; i < array.Length; i++)
            {
                if(i < halfIndex)
                {
                    left.Add(array[i]);
                }
                else
                {
                    right.Add(array[i]);
                }
            }
            return (left.ToArray(), right.ToArray());
        }

        public (long[], long[]) SplitToPositiveAndNegative(long[] array)
        {
            List<long> positive = new List<long>();
            List<long> negative = new List<long>();

            for (int i = 0; i < array.Length; i++)
            {
                if(array[i] < 0)
                {
                    negative.Add(array[i]);
                }
                else
                {
                    positive.Add(array[i]);
                }
            }

            return (positive.ToArray(), negative.ToArray());
        }
    }
}
