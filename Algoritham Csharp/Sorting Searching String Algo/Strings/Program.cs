using System;

namespace Strings
{
    class Program
    {
        static string text = "alibaba and aliexspress";
        static string pattern = "spress";

        static void Main()
        {
            int result = RabinKarp(text, pattern);
            Console.WriteLine("rabin-karp  " + result);
            result = Naive();
            Console.WriteLine("naive  " + result);
            result = KnuthMorissPratt(text, pattern);
            Console.WriteLine("kmp: " + result);
            var prefix = ComputeSubfix(pattern);
            Console.WriteLine(pattern);
            Console.WriteLine(string.Join("", prefix));
        }

        //Naive Search Algorithm Worst: 0(m*n)
        static int Naive()
        {
            int length = text.Length - pattern.Length;
            int subIndex = 0;
            for (int index = 0; index < length + 1; index++)
            {
                while (text[index + subIndex] == pattern[subIndex])
                {
                    if (subIndex == pattern.Length - 1)
                    {
                        return index;
                    }

                    subIndex++;
                }

                subIndex = 0;
            }

            return -1;
        }

        //Rabin-Karp Search Algorithm Avg: 0(n + m) Worst: 0((n - m) m)
        static int RabinKarp(string text, string pattern)
        {
            int n = text.Length;
            int m = pattern.Length;
            long patternHash = GetHash(pattern, m);
            long textHash = GetHash(pattern, m);
            for (int index = 0; index < n - m; index++)
            {
                textHash = RecalcHash(m, index, m + index, textHash);
                if (textHash == patternHash)
                {
                    return index + 1;
                }
            }

            return -1;
        }

        static long GetHash(string text, int length)
        {
            int prime = 101;
            long hashCode = 0;
            for (int index = 0; index < length; index++)
            {
                long leftSide = (long)text[index];
                long rigthSide = (long)Math.Pow(prime, index);
                hashCode += leftSide * rigthSide;
            }

            return hashCode;
        }

        static long RecalcHash(int length, int oldIndex, int newIndex, long hashCode)
        {
            int prime = 101;
            long oldCharacter = (long)text[oldIndex];
            long newCharacter = (long)text[newIndex];
            hashCode = (hashCode - oldCharacter) / prime;
            hashCode = hashCode + (newCharacter  * (long)Math.Pow(prime, length - 1));
            return hashCode;
        }

        //Knuth-Moriss-Pratt Search Algorithm Worst: 0(n)
        static int KnuthMorissPratt(string text, string pattern)
        {
            int i = 0;
            int j = 0;
            int n = text.Length;
            int m = pattern.Length;
            int[] subfix = ComputeSubfix(pattern);
            while (i < n)
            {
                if (pattern[j] == text[i])
                {
                    j++;
                    i++;
                }
                if (j == m)
                {
                    return i - j;
                }
                else if (i < n && pattern[j] != text[i])
                {
                    if (j != 0)
                    {
                        j = subfix[j - 1];
                    }
                    else
                    {
                        i = i + 1;
                    }
                }
            }

            return -1;
        }

        static int[] ComputeSubfix(string pattern)
        {
            int m = pattern.Length;
            int length = 0;
            int[] subfix = new int[m];
            subfix[0] = 0;
            for(int index = 1; index < m; index++)
            {
                if (pattern[index] == pattern[length])
                {
                    length++;
                    subfix[index] = length;
                }
                else
                {
                    if (length != 0)
                    {
                        length = subfix[length - 1];
                        index--;
                    }
                    else
                    {
                        subfix[index] = 0;
                    }
                }
            }

            return subfix;
        }
    }
}
