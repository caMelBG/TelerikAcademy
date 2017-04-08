namespace GenerateOrderedPasswordOfGivenLengthN
{
    using System;

    class GenerateOrderedPasswordOfGivenLengthN
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Solve(n, 0, 0, new int[n]);
        }

        static void Solve(int len, int currLen, int start, int[] password)
        {
            if (currLen == len)
            {
                Console.WriteLine(string.Join(", ", password));
                return;
            }

            for (int index = start + 1; index <= 9; index++)
            {
                password[currLen] = index;
                Solve(len, currLen + 1, index, password);
            }
        }
    }
}
