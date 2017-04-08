namespace ChampionshipOrganizer
{
    using System;

    class ChampionshipOrganizer
    {
        static int n;
        static int[][] matrix;

        static void Main()
        {
            Console.Write("Please enter number of teams: ");
            n = int.Parse(Console.ReadLine());
            matrix = new int[n - 1][];
            FillingMatrix();


            while (true)
            {
                Console.Write("Enter first team: ");
                int firstTeam = int.Parse(Console.ReadLine());
                Console.Write("Enter second team: ");
                int secondTeam = int.Parse(Console.ReadLine());

                int col = 0;
                int group = 0;
                if (firstTeam == secondTeam)
                {
                    Console.WriteLine("You can not check same team!");
                    continue;
                }
                else if (firstTeam < secondTeam)
                {
                    col = (n - 1) - secondTeam;
                    group = matrix[firstTeam - 1][col];
                }
                else if (firstTeam > secondTeam)
                {
                    col = (n - 1) - firstTeam;
                    group = matrix[secondTeam - 1][col];
                }

                Console.WriteLine("Teams {0} and {1} are in the {2} group!"
                    , firstTeam, secondTeam, group);
            }
        }

        static void FillingMatrix()
        {
            for (int index = 0; index < n - 1; index++)
            {
                matrix[index] = new int[n - index - 1];
            }

            int x = 1;
            for (int i = 0; i < n - 1; i++)
            {
                x += i + 1;
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (x >= n)
                    {
                        x = x - (n - 1);
                    }

                    matrix[i][j] = x;
                    x++;
                }
            }

            for (int i = 0; i < n - 1; i++)
            {
                var spaces = new string(' ', i);
                Console.Write(spaces);
                for (int j = 0; j < n - i - 1; j++)
                {
                    Console.Write(matrix[i][j]);
                }

                Console.WriteLine();
            }
        }
    }
}
