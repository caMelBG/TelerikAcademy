namespace GroupPermutations
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class GroupPermutations
    {
        static char[] input = { 'B', 'C', 'A', 'B', 'A', 'C', 'B' };
        static Dictionary<char, int> myDictionary = new Dictionary<char, int>();

        static void Main()
        {
            ReadInput();
            char[] array = new char[myDictionary.Count];
            int index = 0;

            foreach (var item in myDictionary)
            {
                array[index] = item.Key;
                index++;
            }

            GeneratePermutations(array, 0);
        }

        static void GeneratePermutations(char[] array, int index)
        {
            if (index >= array.Length)
            {
                Print(array);
            }
            else
            {
                GeneratePermutations(array, index + 1);
                for (int i = index + 1; i < array.Length; i++)
                {
                    Swap(ref array[index], ref array[i]);
                    GeneratePermutations(array, index + 1);
                    Swap(ref array[index], ref array[i]);
                }
            }
        }

        static void Print(char[] array)
        {
            StringBuilder output = new StringBuilder();
            foreach (char symbole in array)
            {
                for (int i = 0; i < myDictionary[symbole]; i++)
                {
                    output.Append(symbole);
                }
            }

            Console.WriteLine(output.ToString());
        }

        static void Swap(ref char first, ref char second)
        {
            char oldFirst = first;
            first = second;
            second = oldFirst;
        }

        static void ReadInput()
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (!myDictionary.ContainsKey(input[i]))
                {
                    myDictionary.Add(input[i], 1);
                }
                else
                {
                    myDictionary[input[i]]++;
                }
            }
        }
    }
}