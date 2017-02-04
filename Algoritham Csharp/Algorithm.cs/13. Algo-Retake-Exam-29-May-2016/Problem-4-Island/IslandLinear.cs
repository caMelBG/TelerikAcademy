namespace Island
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class IslandLinear
    {
        static void Main(string[] args)
        {
            var heights = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var maxArea = 0;
            var leftCount = new int[heights.Length];
            var columnsOnLeft = new Stack<int>(heights.Length);
            columnsOnLeft.Push(0);

            for (int i = 1; i < heights.Length; i++)
            {
                var current = heights[i];
                var leftBigger = i;
                while (columnsOnLeft.Count > 0 && heights[columnsOnLeft.Peek()] >= current)
                {
                    var j = columnsOnLeft.Pop();
                    var rightCount = i - j;
                    var area = (leftCount[j] + rightCount) * heights[j];
                    if (area > maxArea)
                    {
                        maxArea = area;
                    }
                }

                leftBigger = columnsOnLeft.Count == 0 ? 0 : columnsOnLeft.Peek() + 1;

                leftCount[i] = i - leftBigger;
                columnsOnLeft.Push(i);
            }

            while (columnsOnLeft.Count > 0)
            {
                var j = columnsOnLeft.Pop();
                var right = heights.Length - j;
                var area = (leftCount[j] + right) * heights[j];
                if (area > maxArea)
                {
                    maxArea = area;
                }
            }

            Console.WriteLine(maxArea);
        }
    }
}
