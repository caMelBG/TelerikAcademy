namespace Football.Console
{
    using System;
    using System.Linq;

    public class StartUp
    {
        static void Main()
        {
            var matrix = new int[2, 2];
            for (int i = 0; i < 10; i++)
            {
                matrix[0, 0] = i;
                for (int j = 0; j < 10; j++)
                {
                    matrix[0, 1] = j;
                    for (int k = 0; k < 10; k++)
                    {
                        matrix[1, 0] = k;
                        for (int l = 0; l < 10; l++)
                        {
                            matrix[1, 1] = l;
                            if (
                                matrix[0, 0] + matrix[0, 1] == 8 &&
                                matrix[0, 0] + matrix[1, 0] == 13 &&
                                matrix[1, 0] - matrix[1, 1] == 6 &&
                                matrix[0, 1] + matrix[1, 1] == 8)
                            {
                                break;
                            }
                        }
                    }
                }
            }

            var exporter = new MatchesGenerator();
            exporter.ParseXML();


            

        }

        private static void TestDatabaseConnection()
        {
            using (var db = new FootballEntities())
            {
                var teams = db.Teams.Select(t => t.TeamName).ToList();
                foreach (var team in teams)
                {
                    Console.WriteLine(team);
                }
            }
        }
    }
}
