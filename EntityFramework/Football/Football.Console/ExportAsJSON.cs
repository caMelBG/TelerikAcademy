namespace Football.Console
{
    using Newtonsoft.Json;
    using System.IO;
    using System.Linq;

    public class ExportAsJSON
    {
        private const string JsonFileLocation = @"../../leagues-and-teams.json";

        public void ExportLeaguesWithMatchesFromDatabase()
        {
            using (var db = new FootballEntities())
            {
                var leagues = db.Leagues
                    .OrderBy(l => l.LeagueName)
                    .Select(l => new
                    {
                        leaguename = l.LeagueName,
                        teams = l.Teams
                            .OrderBy(t => t.TeamName)
                            .Select(t => t.TeamName)
                    })
                    .AsEnumerable();

                foreach (var league in leagues)
                {
                    System.Console.WriteLine(league.leaguename);
                    foreach (var team in league.teams)
                    {
                        System.Console.WriteLine(string.Concat("----", team));
                    }
                }


                var jsonAsText = JsonConvert.SerializeObject(leagues, Formatting.Indented);
                File.WriteAllText(JsonFileLocation, jsonAsText);
            }
        }
    }
}

