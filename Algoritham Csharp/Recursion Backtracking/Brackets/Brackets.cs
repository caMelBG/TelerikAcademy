namespace Brackets
{
    using System;

    class Brackets
    {
        static void Main()
        {
            string line = "??????";
            int len = line.Length + 1;
            int[][] dpMatrix = new int[len][];

            for (int i = 0; i < len; i++)
            {
                dpMatrix[i] = new int[len];
            }

            dpMatrix[0][0] = 1;

            int left = 0;
            int right = 0;
            for (int i = 0; i < len - 1; i++)
            {
                if (line[i] == '(')
                {
                    right = 1;
                    left = len;
                }
                else if (line[i] == ')')
                {
                    right = len;
                    left = 1;
                }
                else
                {
                    right = 1;
                    left = 1;
                }
                for (int j = 0; j < len; j++)
                {
                    int curr = dpMatrix[i][j];
                    if (curr >= 1)
                    {
                        if (j - left >= 0)
                        {
                            dpMatrix[i + 1][j - left] += curr;
                        }
                        if (j + right < len)
                        {
                            dpMatrix[i + 1][j + right] += curr;
                        }
                    }
                }
            }

            for (int i = 0; i < len; i++)
            {
                Console.Write(i + " -> ");
                for (int j = 0; j < len; j++)
                {
                    Console.Write(dpMatrix[i][j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
