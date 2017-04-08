namespace Words
{
    using System;
    using System.Collections.Generic;

    class Words
    {
        static HashSet<string> words = new HashSet<string>();
        static char[] characters;
        static int combinationCount;

        static void Main()
        {
            ReadInput();
            PermuteRep(characters, 0, characters.Length);
            Print();
        }

        static void PermuteRep(char[] array, int start, int n)
        {
            Counting(array);

            for (int left = n - 2; left >= start; left--)
            {
                for (int right = left + 1; right < n; right++)
                {
                    if (array[left] != array[right])
                    {
                        Swap(ref array[left], ref array[right]);
                        PermuteRep(array, left + 1, n);
                    }
                }

                var firstElement = array[left];
                for (int i = left; i < n - 1; i++)
                {
                    array[i] = array[i + 1];
                }

                array[n - 1] = firstElement;
            }
        }

        static void Swap<T>(ref T first, ref T second)
        {
            T oldFirst = first;
            first = second;
            second = oldFirst;
        }

        static void Counting(char[] array)
        {
            bool isEqual = false;

            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] == array[i + 1])
                {
                    isEqual = true;
                }
            }

            if (!isEqual)
            {
                string currentWord = new string(array);
                if (!words.Contains(currentWord))
                {
                    words.Add(currentWord);
                    combinationCount++;
                }
            }
        }

        static void Print()
        {
            Console.WriteLine(combinationCount);
        }

        static void ReadInput()
        {
            characters = Console.ReadLine().ToCharArray();
        }
    }
}
