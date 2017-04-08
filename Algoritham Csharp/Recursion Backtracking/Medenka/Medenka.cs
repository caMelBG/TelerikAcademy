namespace Medenka
{
    using System;
    using System.Linq;

    class Medenka
    {
        static char[] array;
        static int nuts;

        static void Main()
        {
            ReadInput();
            Solve(0, 1);
        }

        static void Solve(int index, int start)
        {
            if (index == nuts)
            {
                if (Verified())
                {
                    Print();
                }
            }
            else
            {
                for (int i = start; i < array.Length; i += 2)
                {
                    array[i] = '|';
                    Solve(index + 1, i + 2);
                    array[i] = ' ';
                }
            }
        }

        static bool Verified()
        {
            bool hasNut = false;
            foreach (var item in array)
            {
                if (item == '1')
                {
                    if (hasNut)
                    {
                        return false;
                    }

                    hasNut = true;
                }
                else if (item == '|')
                {
                    if (!hasNut)
                    {
                        return false;
                    }

                    hasNut = false;
                }
            }

            return true;
        }

        static void Print()
        {
            foreach (var item in array)
            {
                if (item != ' ')
                {
                    Console.Write(item);
                }
            }

            Console.WriteLine();
        }

        static void ReadInput()
        {
            string line = Console.ReadLine();
            char[] tempArray = line.Split(' ').Select(x => char.Parse(x)).ToArray();
            nuts = tempArray.Where(x => x == '1').Count() - 1;
            array = new char[tempArray.Length * 2 - 1];
            FillingArray(tempArray);
        }

        static void FillingArray(char[] tempArray)
        {
            int index = 0;
            foreach (char item in tempArray)
            {
                array[index] = item;
                if (index < array.Length - 1)
                {
                    array[index + 1] = ' ';
                }

                index += 2;
            }
        }
    }
}