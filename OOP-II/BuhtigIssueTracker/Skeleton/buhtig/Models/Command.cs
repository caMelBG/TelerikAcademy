namespace BuhtigIssueTracker.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using Interfaces;

    public class Command : ICommand
    {
        public Command(string url)
        {
            this.ParseName(url);
        }

        public string Name { get; set; }

        public IDictionary<string, string> Parameters { get; set; }

        private void ParseName(string url)
        {
            int questionMark = url.IndexOf('?');
            if (questionMark != -1)
            {
                this.Name = url.Substring(0, questionMark);
                this.ParseParameters(url.Substring(questionMark + 1));
            }
            else
            {
                this.Name = url;
            }
        }

        private void ParseParameters(string parametersParts)
        {
            var pairs = parametersParts
                    .Split('&')
                    .Select(x => x.Split('=')
                    .Select(xx => WebUtility.UrlDecode(xx))
                    .ToArray());
            var parameters = new Dictionary<string, string>();
            foreach (var pair in pairs)
            {
                parameters.Add(pair[0], pair[1]);
            }

            this.Parameters = parameters;
        }
    }
}