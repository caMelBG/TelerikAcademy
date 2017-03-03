namespace Football.Console
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    public class MatchesGenerator
    {
        private const string XMLFileLocation = @"../../generate-matches.xml";

        public void ParseXML()
        {
            var xmlDoc = XDocument.Load(XMLFileLocation);
            var details = xmlDoc.Descendants("generate");
            int index = 0;
            foreach (var detail in details)
            {
                Console.WriteLine("Processing request #{0} ...", ++index);
                var generateCount = detail.Attribute("generate-count");
                var maxGoals = detail.Attribute("max-goals");
                var league = detail.Element("league");
                var startDate = detail.Element("start-date");
                var endDate = detail.Element("end-date");
                this.GenerateRandomMatch(generateCount, maxGoals, league, startDate, endDate);
                Console.WriteLine();
            }
        }

        private void GenerateRandomMatch(XAttribute generateCount, XAttribute maxGoals, XElement league, XElement startDate, XElement endDate)
        {
            int generateCountValue = 10;
            int maxGoalsValue = 5;
            string leagueValue = "no league";
            DateTime startDateValue = new DateTime(2000, 1, 1);
            DateTime endDateValue = new DateTime(2015, 12, 31);

            if (generateCount != null)
            {
                generateCountValue = int.Parse(generateCount.Value);
            }

            if (maxGoals != null)
            {
                maxGoalsValue = int.Parse(maxGoals.Value);
            }

            if (league != null)
            {
                leagueValue = league.Value;
            }

            if (startDate != null)
            {
                startDateValue = DateTime.Parse(startDate.Value);
            }

            if (endDate != null)
            {
                endDateValue = DateTime.Parse(endDate.Value);
            }

            for (int index = 0; index < generateCountValue; index++)
            {
                var firstTeam = this.GetRandomTeamByLeague(leagueValue);
                var secondTeam = this.GetRandomTeamByLeague(leagueValue);
                while (firstTeam.Id == secondTeam.Id)
                {
                    secondTeam = this.GetRandomTeamByLeague(leagueValue);
                }

                var matchDate = this.GetRandomDate(startDateValue, endDateValue);
                var firstTeamGoals = new Random().Next(0, maxGoalsValue);
                var secondTeamGoals = new Random().Next(0, maxGoalsValue - firstTeamGoals);
                this.ImportMatch(firstTeam, secondTeam, firstTeamGoals, secondTeamGoals, matchDate, leagueValue);
            }
        }

        private void ImportMatch(Team fTeam, Team sTeam, int fTeamGoals, int sTeamGoals, DateTime date, string leagueName)
        {
            Console.WriteLine($"{date.ToString("dd MMM yyyy")}: {fTeam.TeamName} - {sTeam.TeamName}: {fTeamGoals}-{sTeamGoals} ({leagueName})");
            League league = null;
            using (var db = new FootballEntities())
            {
                if (leagueName != "no league")
                {
                    league = db.Leagues.FirstOrDefault(l => l.LeagueName == leagueName);
                }

                var teamMatch = new TeamMatch()
                {
                    League = league,
                    Team = fTeam,
                    Team1 = sTeam,
                    HomeGoals = fTeamGoals,
                    AwayGoals = sTeamGoals,
                    MatchDate = date
                };
                db.TeamMatches.Add(teamMatch);
                db.SaveChanges();
            }
        }

        private Team GetRandomTeamByLeague(string league)
        {
            using (var db = new FootballEntities())
            {
                Team team = null;
                if (league == "no league")
                {
                    var maxId = db.Teams.Max(t => t.Id);
                    var minid = db.Teams.Min(t => t.Id);
                    var randId = new Random().Next(minid, maxId);
                    team = db.Teams.Where(t => t.Id == randId).FirstOrDefault();
                }
                else
                {
                    var maxId = db.Teams.Where(t => t.Leagues.Any(l => l.LeagueName == league)).Max(t => t.Id);
                    var minid = db.Teams.Where(t => t.Leagues.Any(l => l.LeagueName == league)).Min(t => t.Id);
                    var randId = new Random().Next(minid, maxId);
                    team = db.Teams.Where(t => t.Id == randId).FirstOrDefault();
                }

                return team;
            }
        }

        private DateTime GetRandomDate(DateTime start, DateTime end)
        {
            var randDays = new Random().Next((end - start).Days);
            return start.AddDays(randDays);
        }
    }
}
