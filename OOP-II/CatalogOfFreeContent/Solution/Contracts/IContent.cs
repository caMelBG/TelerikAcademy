using CatalogOfFreeContent.Enums;
using System;

namespace CatalogOfFreeContent.Contracts
{
    public interface IContent : IComparable
    {
        string Title { get; set; }

        string Author { get; set; }

        int Size { get; set; }

        string URL { get; set; }

        ContentType Type { get; set; }

        string TextRepresentation { get; set; }
    }
}
