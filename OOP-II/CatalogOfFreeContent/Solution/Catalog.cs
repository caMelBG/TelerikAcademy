using System.Linq;
using System.Text;
using System.Collections.Generic;

using Wintellect.PowerCollections;
using CatalogOfFreeContent.Contracts;

namespace CatalogOfFreeContent
{
    class Catalog : ICatalog
    {
        private MultiDictionary<string, IContent> url;
        private OrderedMultiDictionary<string, IContent> title;

        public Catalog()
        {
            bool allowDuplicateValues = true;
            this.title = new OrderedMultiDictionary<string, IContent>(allowDuplicateValues);
            this.url = new MultiDictionary<string, IContent>(allowDuplicateValues);
        }

        public void Add(IContent content)
        {
            this.title.Add(content.Title, content);
            this.url.Add(content.URL, content);
        }

        public int UpdateContent(string oldUrl, string newUrl)
        {
            int theElements = 0;

            List<IContent> contentToList = this.url[oldUrl].ToList();
            foreach (Content content in contentToList)
            {
                this.title.Remove(content.Title, content);
                theElements++;
            }

            this.url.Remove(oldUrl);
            foreach (IContent content in contentToList)
            {
                content.URL = newUrl;
                this.title.Add(content.Title, content);
                this.url.Add(content.URL, content);
            }

            return theElements;
        }

        public string Find(ICatalog catalog, ICommand command)
        {
            var myString = new StringBuilder();
            int numberOfElementsToList = int.Parse(command.Parameters[1]);

            IEnumerable<IContent> foundContent = catalog
                .GetListContent(command.Parameters[0], numberOfElementsToList);

            if (foundContent.Count() == 0)
            {
                return "No items found";
            }
            foreach (IContent content in foundContent)
            {
                myString.AppendLine(content.TextRepresentation);
            }
        
            return myString.ToString().Trim();
        }

        public IEnumerable<IContent> GetListContent(string title, int numberOfContentElementsToList)
        {
            IEnumerable<IContent> contentToList = from c in this.title[title] select c;

            return contentToList.Take(numberOfContentElementsToList);
        }
    }
}
