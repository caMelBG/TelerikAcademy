namespace ShortestPath
{
    using System;
    using System.Linq;

    class ShortestPath
    {
        static char[] ways = new char[] { 'L', 'S', 'R' };
        static char[] path;
        static int stars;

        static void Main()
        {
            path = Console.ReadLine().ToCharArray();
            stars = path.Where(x => x == '*').Count();
            Find(0);
        }

        static void Find(int index)
        {
            if (index == stars)
            {
                Console.WriteLine(new string(path));
            }
            else
            {
                for (int way = 0; way < ways.Length; way++)
                {
                    for (int i = index; i < path.Length; i++)
                    {
                        if (path[i] == '*')
                        {
                            path[i] = ways[way];
                            Find(index + 1);
                        }
                    }
                }
            }
        }
    }
}