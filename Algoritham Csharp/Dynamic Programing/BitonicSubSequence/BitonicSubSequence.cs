namespace BitonicSubSequence
{
    using System;

    class BitonicSubSequence
    {
        static int[] array = new int[] { 0, 10, 20, 15, 40, 5, 4, 300, 2, 1 };
        static int[] incr = new int[array.Length];
        static int[] desc = new int[array.Length];
        static int[] res = new int[array.Length];

        static void Main()
        {
            incr[0] = 1;
            for (int i = 1; i < array.Length; i++)
            {
                incr[i] = 1;
                for (int j = i - 1; j >= 0; j--)
                {
                    if (array[i] > array[j] && incr[i] < incr[j] + 1)
                    {
                        incr[i] = incr[j] + 1;
                    }
                }
            }

            desc[desc.Length - 1] = 1;
            for (int i = desc.Length - 2; i >= 0; i--)
            {
                desc[i] = 1;
                for (int j = i + 1; j < desc.Length; j++)
                {
                    if (array[i] > array[j] && desc[i] < desc[j] + 1)
                    {
                        desc[i] = desc[j] + 1;
                    }
                }
            }

            int max = 0;
            for (int i = 0; i < array.Length; i++)
            {
                res[i] = desc[i] + incr[i] - 1;
                if (res[i] > max)
                {
                    max = res[i];
                }
            }

            Console.WriteLine(max);
        }
    }
}
