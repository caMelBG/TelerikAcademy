namespace BuhtigIssueTracker.Models
{
    using System;
    using System.Text;

    public class Comment
    {
        private string text;

        public Comment(User author, string text)
        {
            this.Author = author;
            this.Text = text;
        }

        public User Author { get; private set; }

        public string Text
        {
            get
            {
                return this.text;
            }

            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 2)
                {
                    throw new ArgumentException("The text must be at least 2 symbols long");
                }

                this.text = value;
            }
        }

        public override string ToString()
        {
            return new StringBuilder()
                .AppendLine(Text)
                .AppendFormat("-- {0}", Author.Username)
                .AppendLine()
                .ToString()
                .Trim();
        }
    }
}