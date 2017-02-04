using System;

using CatalogOfFreeContent.Contracts;
using CatalogOfFreeContent.Enums;

namespace CatalogOfFreeContent
{
    public class Content : IComparable, IContent
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public int Size { get; set; }

        private string url;

        public string URL
        {
            get
            {
                return this.url;
            }
            set
            {
                this.url = value;
                this.TextRepresentation = this.ToString();
            }
        }

        public ContentType Type { get; set; }

        public string TextRepresentation { get; set; }

        ContentType IContent.Type { get; set; }

        public Content(ContentType type, string[] commandParams)
        {
            this.Type = type;
            this.Title = commandParams[(int)ContentItems.Title];
            this.Author = commandParams[(int)ContentItems.Author];
            this.Size = int.Parse(commandParams[(int)ContentItems.Size]);
            this.URL = commandParams[(int)ContentItems.Url];
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            Content otherContent = obj as Content;
            if (otherContent != null)
            {
                int comparisonResul = this.TextRepresentation.CompareTo(otherContent.TextRepresentation);

                return comparisonResul;
            }

            throw new ArgumentException("Object is not a Content");
        }

        public override string ToString()
        {
            string output = String.Format("{0}: {1}; {2}; {3}; {4}",
                this.Type.ToString(), this.Title, this.Author, this.Size, this.URL);

            return output;
        }
    }
}
