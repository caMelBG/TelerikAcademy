namespace Bridges
{
    using System;

    class Bridges
    {
        static int[] array = new int[] { 1, 2, 3, 1, 2, 3, 2, 2, 3 };
        static int count = 0;

        static void Main()
        {
            Find(0, 1);
            string output = "{0} {1} found.";
            string bridgeString = count > 1
                ? "bridges"
                : "bridge";
            if (count == 0)
            {
                Console.WriteLine("No bridges found");
            }
            else
            {
                Console.WriteLine(output, count, bridgeString);
            }
        }

        static void Find(int start, int index)
        {
            if (index == array.Length)
            {
                return;
            }

            for (int i = start; i < index; i++)
            {
                if (array[i] == array[index])
                {
                    start = index;
                    count++;
                    break;
                }
            }

            Find(start, index + 1);
        }
    }
}