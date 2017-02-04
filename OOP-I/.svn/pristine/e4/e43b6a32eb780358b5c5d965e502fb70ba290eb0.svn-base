using System;
using Dealership.Contracts;
using Dealership.Common;

namespace Dealership.Models
{
    public class Comment : IComment
    {
        private string content;

        public Comment(string content)
        {
            this.Content = content;
        }

        public string Author { get; set; }

        public string Content
        {
            get
            {
                return this.content;
            }

            private set
            {
                Validator.ValidateIntRange(
                    value.Length,
                    Constants.MinCommentLength,
                    Constants.MaxCommentLength,
                    String.Format(
                        Constants.StringMustBeBetweenMinAndMax,
                        Constants.MinCommentLength,
                        Constants.MaxCommentLength));
                this.content = value;
            }
        }
    }
}
