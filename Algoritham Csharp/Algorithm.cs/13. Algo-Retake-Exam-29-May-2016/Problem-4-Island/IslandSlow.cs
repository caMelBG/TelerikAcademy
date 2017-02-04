using System;
using System.Collections.Generic;

namespace Island_Slow
{
    public class IslandSlow
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
            
            var leftColumns = new int[columns.Count];
            var rightColumns = new int[columns.Count];

            FindBiggerColumnsToLeft(columns, leftColumns);

            FindBiggerColumnsToRight(columns, rightColumns);

            var maxArea = 0;
            for (int i = 0; i < columns.Count; i++)
            {
                var width = leftColumns[i] + rightColumns[i] + 1;
                var area = width * columns[i];
                if (area > maxArea)
                {
                    maxArea = area;
                }
            }
            
            Console.WriteLine(maxArea)
        }

        private static void FindBiggerColumnsToRight(List<int> columns, int[] rightColumns)
        {
            for (int i = columns.Count - 2; i >= 0; i--)
            {
                int j;
                for (j = i + 1; j < columns.Count; j++)
                {
                    if (columns[j] < columns[i])
                    {
                        break;
                    }
                }

                rightColumns[i] = j - i - 1;
            }
        }

        private static void FindBiggerColumnsToLeft(List<int> columns, int[] leftColumns)
        {
            for (int i = 1; i < columns.Count; i++)
            {
                int j;
                for (j = i - 1; j >= 0; j--)
                {
                    if (columns[j] < columns[i])
                    {
                        break;
                    }
                }

                leftColumns[i] = i - j - 1;
            }
        }
    }
}
