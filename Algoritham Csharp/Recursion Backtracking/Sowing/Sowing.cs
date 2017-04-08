namespace Sowing
{
    using System;
    using System.Collections.Generic;

    class Sowing
    {
        static int n = 3;
        static int k = 6;
        static char[] array = { '1', '1', '1', '1', '0', '1' };
        static HashSet<char[]> output = new HashSet<char[]>();

        static void Main()
        {
            //ReadInput();
            Find(0, 0);
            Print();
        }

        static void Find(int index, int start)
        {
            if (index >= n)
            {
                if (Verificied() == true)
                {
                    var temp = new char[k];
                    Array.Copy(array, temp, k);
                    output.Add(temp);
                }

                return;
            }

            for (int i = start; i < k; i++)
            {
                if (array[i] == '1')
                {
                    char temp = array[i];
                    array[i] = '.';
                    Find(index + 1, i + 1);
                    array[i] = temp;
                }
            }
        }

        static bool Verificied()
        {
            int count = 0;
            for (int i = 0; i < k; i++)
            {
                if (array[i] == '.')
                {
                    count++;
                }
            }

            if (count == n)
            {
                for (int i = 1; i < k; i++)
                {
                    if (array[i] == '.' && array[i - 1] == '.')
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }

        static void Print()
        {
            foreach (var line in output)
            {
                Console.WriteLine(new string(line));
            }
        }

        static void ReadInput()
        {
            n = int.Parse(Console.ReadLine());
            array = Console.ReadLine().ToCharArray();
            k = array.Length;
        }
    }
}