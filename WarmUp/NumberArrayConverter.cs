using System;
using System.Collections.Generic;
using System.Text;

namespace WarmUp
{
    public class NumberArrayConverter
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
    }
}
