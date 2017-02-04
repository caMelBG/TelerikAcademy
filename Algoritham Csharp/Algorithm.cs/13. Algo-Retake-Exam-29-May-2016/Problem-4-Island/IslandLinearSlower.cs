namespace Island
{
    using System;
    using System.Collections.Generic;

    public class IslandSolution
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(' ');
            var columns = new int[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                columns[i] = int.Parse(input[i]);
            }
            
            var leftColumns = new int[columns.Length];
            var rightColumns = new int[columns.Length];

            FindBiggerColumnsToLeft(columns, leftColumns);

            FindBiggerColumnsToRight(columns, rightColumns);

            var maxArea = 0;
            for (int i = 0; i < columns.Length; i++)
            {
                var width = leftColumns[i] + rightColumns[i] + 1;
                var area = width * columns[i];
                if (area > maxArea)
                {
                    maxArea = area;
                }
            }

            Console.WriteLine(maxArea);
        }

        private static void FindBiggerColumnsToRight(int[] columns, int[] rightColumns)
        {
            var columnsOnRight = new Stack<int>(columns.Length);
            columnsOnRight.Push(columns.Length - 1);
            for (int i = columns.Length - 2; i >= 0; i--)
            {
                var current = columns[i];
                var rightMostBigger = i;
                while (columnsOnRight.Count > 0 && columns[columnsOnRight.Peek()] >= current)
                {
                    columnsOnRight.Pop();
                }

                rightMostBigger = columnsOnRight.Count == 0 ? columns.Length - 1 : columnsOnRight.Peek() - 1;

                rightColumns[i] = rightMostBigger - i;
                columnsOnRight.Push(i);
            }
        }

        private static void FindBiggerColumnsToLeft(int[] columns, int[] leftColumns)
        {
            var columnsOnLeft = new Stack<int>(columns.Length);
            columnsOnLeft.Push(0);
            for (int i = 1; i < columns.Length; i++)
            {
                var current = columns[i];
                var leftmostBigger = i;
                while (columnsOnLeft.Count > 0 && columns[columnsOnLeft.Peek()] >= current)
                {
                    columnsOnLeft.Pop();
                }

                leftmostBigger = columnsOnLeft.Count == 0 ? 0 : columnsOnLeft.Peek() + 1;

                leftColumns[i] = i - leftmostBigger;
                columnsOnLeft.Push(i);
            }
        }
    }
}
