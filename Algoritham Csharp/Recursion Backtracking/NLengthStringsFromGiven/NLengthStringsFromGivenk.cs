namespace NLengthStringsFromGivenK
{
    using System;

    class NLengthStringsFromGivenK
    {
        static void Main()
        {
            int n = 2;
            int k = 3;
            Solve(n, k, 0, new int[n]);

        }

        static void Solve(int n, int k, int currLength, int[] sequence)
        {
            if (currLength == n)
            {
                Console.WriteLine(string.Join(", ", sequence));
                return;
            }

            for (int index = 1; index <= k; index++)
            {
                sequence[n - 1 - currLength] = index;
                Solve(n, k, currLength + 1, sequence);
            }
        }
    }
}
