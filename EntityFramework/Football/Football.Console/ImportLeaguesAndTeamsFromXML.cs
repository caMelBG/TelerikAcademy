namespace Football.Console
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    public class ImportLeaguesAndTeamsFromXML
    {
        private const string XMLFileLocation = @"../../leagues-and-teams.xml";
        private FootballEntities db;

        public void Import()
        {
            this.db = new FootballEntities();
            var xmlDoc = XDocument.Load(XMLFileLocation);
            var leagues = xmlDoc.Descendants("league");
            var leagueIndex = 0;
            foreach (var league in leagues)
            {
                Console.WriteLine("Processing league #{0} ...", ++leagueIndex);
                this.AddLeagueIfNotExists(league);
                var teams = league.Descendants("team");
                foreach (var team in teams)
                {
                    this.AddTeamIfNotExists(team);
                    this.AddRelationBetweenTeamsAndLeagues(league, team);
                }

                Console.WriteLine();
            }
        }

        private void AddLeagueIfNotExists(XElement xLeague)
        {
            if (xLeague == null)
            {
                return;
            }

            var leagueName = xLeague.Value;
            bool isExists = db.Leagues.Any(l => l.LeagueName == leagueName);
            if (!isExists)
            {
                db.Leagues.Add(new League() { LeagueName = leagueName });
                Console.WriteLine("Created league: {0}", leagueName);
                db.SaveChanges();
            }
            else
            {
                if (leagueName != string.Empty)
                {
                    Console.WriteLine("Existing league: {0}", leagueName);
                }
            }
        }

        private void AddTeamIfNotExists(XElement xTeam)
        {
            if (xTeam == null)
            {
                return;
            }

            var teamName = xTeam.Attribute("name").Value;
            var teamCountry = xTeam.Attribute("country");
            if (teamCountry == null)
            {
                bool isExists = db.Teams.Any(t => t.TeamName == teamName);
                if (!isExists)
                {
                    Console.WriteLine("Created team: {0} (no country)", teamName);
                    db.Teams.Add(new Team() { TeamName = teamName });
                    db.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Existing team: {0} (no country)", teamName);
                }
            }
            else
            {
                bool isExists = db.Teams.Any(t => t.TeamName == teamName && t.Country.CountryName == teamCountry.Value);
                if (!isExists)
                {
                    Console.WriteLine("Created team: {0} ({1})", teamName, teamCountry.Value);
                    var country = db.Countries.FirstOrDefault(c => c.CountryName == teamCountry.Value);
                    db.Teams.Add(new Team()
                    {
                        TeamName = teamName,
                        Country = country
                    });
                    db.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Existing team: {0} ({1})", teamName, teamCountry.Value);
                }
            }

        }

        private void AddRelationBetweenTeamsAndLeagues(XElement xLeague, XElement xTeam)
        {
            if (xLeague.Element("league-name") == null || xTeam.Attribute("name") == null)
            {
                return;
            }
            
            var teamName = xTeam.Attribute("name").Value;
            var leagueName = xLeague.Element("league-name").Value;
            var team = db.Teams.FirstOrDefault(t => t.TeamName == teamName);
            var league = db.Leagues.FirstOrDefault(l => l.LeagueName == leagueName);
            if (!(league.Teams.Contains(team) && team.Leagues.Contains(league)))
            {
                Console.WriteLine("Added team to league: {0} to league {1}", teamName, leagueName);
                league.Teams.Add(team);
                team.Leagues.Add(league);
                db.SaveChanges();
            }
            else
            {
                Console.WriteLine("Existing team in league: {0} belongs to {1}", teamName, leagueName);
            }
        }
    }
}
