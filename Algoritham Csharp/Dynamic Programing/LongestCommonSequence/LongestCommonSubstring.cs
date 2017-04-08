namespace LongestCommonSubString
{
    using System;

    class LongestCommonSubstring
    {
        static string first = "aabbbba";
        static string second = "abbbaa";
        static int[,] matrix = new int[first.Length + 1, second.Length + 1];

        static void Main()
        {
            //Solve();
            if (first.Length > second.Length)
            {
                SolveWithArray(second, first);
            }
            else
            {
                SolveWithArray(first, second);
            }
        }

        static void Solve()
        {
            for (int i = 1; i <= first.Length; i++)
            {
                for (int j = 1; j <= second.Length; j++)
                {
                    matrix[i, j] = Math.Max(matrix[i - 1, j], matrix[i, j - 1]);
                    if (first[i - 1] == second[j - 1])
                    {
                        matrix[i, j]++;
                    }
                }
            }

            for (int i = 0; i <= first.Length; i++)
            {
                for (int j = 0; j <= second.Length; j++)
                {
                    Console.Write(matrix[i, j] + "  ");
                }

                Console.WriteLine();
                Console.WriteLine();
            }

        }

        static void SolveWithArray(string shorterString, string longerString)
        {
            int start = 0;
            int[] memoization = new int[shorterString.Length + 1];
            char[] matched = new char[shorterString.Length + 1];
            for (int i = 0; i < shorterString.Length; i++)
            {
                for (int j = start; j < longerString.Length; j++)
                {
                    memoization[i + 1] = memoization[i];
                    if (shorterString[i] == longerString[j])
                    {
                        start = j + 1;
                        memoization[i + 1]++;
                        matched[i + 1] = shorterString[i];
                        break;
                    }
                }
            }

            Console.WriteLine(new string(matched));
            Console.WriteLine(string.Join("", memoization));
        }
    }
}
