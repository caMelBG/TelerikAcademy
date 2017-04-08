namespace CycleShiftedArray
{
    using System;

    class CycleShiftedArray
    {
        static int n = 8;
        static int k = 3;
        static int[] array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };

        static void Main()
        {
            Solve1();
        }

        //Gris and Milz Algoritam
        //REVERSED ARRAY = A AND B1 THEN SWAP B1 AND B2
        static void Solve1()
        {
            int swap = 0;
            for (int index = 0; index < k; index++)
            {
                swap = array[index];
                array[index] = array[index + (n - k)];
                array[index + (n - k)] = swap;
            }

            Console.WriteLine(string.Join(", ", array));
            for (int i = 0; i < n - (2 * k); i++)
            {
                swap = array[k + i];
                for (int j = 0; j < k; j++)
                {

                    array[(k + i) - j] = array[(k + i) - j - 1];
                }

                array[i] = swap;

                Console.WriteLine(string.Join(", ", array));
            }
        }


        //Kernigtan and Plozhek ALgoritam
        //REVERSED ARAY = (A(reverse) + B(reverse))(reverse)    
        static void Solve2()
        {
            int swap = 0;
            for (int index = 0; index < k / 2; index++)
            {
                swap = array[index];
                array[index] = array[k - index - 1];
                array[k - index - 1] = swap;
            }

            Console.WriteLine(string.Join(", ", array));
            for (int index = 0; index < (n - k) / 2; index++)
            {
                swap = array[k + index];
                array[k + index] = array[n - index - 1];
                array[n - index - 1] = swap;
            }

            Console.WriteLine(string.Join(", ", array));
            for (int index = 0; index < n / 2; index++)
            {
                swap = array[index];
                array[index] = array[n - index - 1];
                array[n - index - 1] = swap;
            }

            Console.WriteLine(string.Join(", ", array));
        }
    }
}
