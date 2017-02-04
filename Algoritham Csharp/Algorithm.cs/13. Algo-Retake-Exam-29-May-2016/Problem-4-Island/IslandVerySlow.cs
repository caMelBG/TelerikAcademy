using System;
using System.Collections.Generic;

namespace Island_VerySlow
{
    public class IslandVerySlow
    {
        static void Main(string[] args)
        {
            var columns = new List<int>();
            var input = Console.ReadLine()
                .Split(' ');
            for (int i = 0; i < input.Length; i++)
            {
                columns.Add(int.Parse(input[i]));
            }

            var maxArea = 0;
            for (int i = 0; i < columns.Count; i++)
            {
                var min = columns[i];
                for (int j = i; j < columns.Count; j++)
                {
                    if (columns[j] < min)
                    {
                        min = columns[j];
                    }

                    var area = (j - i + 1) * min;
                    if (area > maxArea)
                    {
                        maxArea = area;
                    }
                }
            }

            Console.WriteLine(maxArea);
        }
    }
}
