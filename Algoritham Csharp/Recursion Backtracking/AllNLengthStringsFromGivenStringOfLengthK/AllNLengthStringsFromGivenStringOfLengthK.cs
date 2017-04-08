namespace AllNLengthStringsFromGivenStringOfLengthK
{
    using System;

    class AllNLengthStringsFromGivenStringOfLengthK
    {
        static void Main()
        {
            string word = "ALGO";
            int n = 2;
            Solve(n, 0, word, new char[n]);
        }

        static void Solve(int len, int currLen, string word, char[] result)
        {
            if (currLen == len)
            {
                Console.WriteLine(result);
                return;
            }

            for (int index = 0; index < word.Length; index++)
            {
                result[len - 1 - currLen] = word[index];
                Solve(len, currLen + 1, word, result);
            }
        }
    }
}
