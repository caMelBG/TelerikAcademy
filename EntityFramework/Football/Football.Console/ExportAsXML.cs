namespace Football.Console
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;

    public class ExportAsXML
    {
        private const string XMLFileLocation = @"../../international-matches.xml";

        public void ExportInternationalMatchesAsXML()
        {
            using (var db = new FootballEntities())
            {
                var matches = db.InternationalMatches
                    .OrderBy(m => m.MatchDate)
                    .ThenBy(m => m.Country)
                    .ThenBy(m => m.Country1)
                    .Select(m => new
                    {
                        Date = m.MatchDate,
                        HomeTeamName = m.Country1.CountryName,
                        HomeTeamCode = m.HomeCountryCode,
                        HomeTeamGoals = m.HomeGoals,
                        AwayTeamName = m.Country.CountryName,
                        AwayTeamCode = m.AwayCountryCode,
                        AwayTeamGoals = m.AwayGoals,
                        LeagueName = m.League.LeagueName
                    })
                    .ToList();

                XElement xmlDoc = new XElement("matches");
                foreach (var match in matches)
                {
                    var matchElement = new XElement("match");

                    if (match.Date != null)
                    {
                        var date = match.Date.Value.ToString("d-MMM-yyyy hh:mm");
                        var matchDateAttribute = new XAttribute("date-time", date);
                        if (match.Date.Value.Hour == 12 &
                            match.Date.Value.Minute == 0 &
                            match.Date.Value.Second == 0 &
                            match.Date.Value.Millisecond == 0)
                        {
                            date = match.Date.Value.ToString("d-MMM-yyyy");
                            matchDateAttribute = new XAttribute("date", date);
                        }

                        matchElement.Add(matchDateAttribute);
                    }
                    
                    var homeTeamNameElement = new XElement("home-country", match.HomeTeamName);
                    var homeTeamCodeAttribute = new XAttribute("code", match.HomeTeamCode);
                    var awayTeamNameElement = new XElement("away-country", match.AwayTeamName);
                    var awayTeamCodeAttribute = new XAttribute("code", match.AwayTeamCode);

                    homeTeamNameElement.Add(homeTeamCodeAttribute);
                    awayTeamNameElement.Add(awayTeamCodeAttribute);
                    matchElement.Add(homeTeamNameElement, awayTeamNameElement);
                    xmlDoc.Add(matchElement);

                    if (match.HomeTeamGoals != null & match.AwayTeamGoals != null)
                    {
                        var scoreElement = new XElement("score",
                            string.Concat(match.HomeTeamGoals, "-", match.AwayTeamGoals));
                        matchElement.Add(scoreElement);
                    }

                    if (match.LeagueName != null)
                    {
                        var leagueNameElement = new XElement("league", match.LeagueName);
                        matchElement.Add(leagueNameElement);
                    }
                }

                var xmlResult = new XDocument();
                xmlResult.Add(xmlDoc);
                xmlResult.Save(XMLFileLocation);
            }
        }
    }
}
