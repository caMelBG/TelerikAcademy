using System;
using System.Text;

using CatalogOfFreeContent.Enums;
using CatalogOfFreeContent.Contracts;

namespace CatalogOfFreeContent
{
    public class CommandExecutor : ICommandExecutor
    {
        public string ExecuteCommand(ICatalog catalog, ICommand command)
        {
            var output = new StringBuilder();
            switch (command.Type)
            {
                case CommandType.AddBook:
                    catalog.Add(new Content(ContentType.Book, command.Parameters));
                    output.AppendLine("Books Added");
                    break;

                case CommandType.AddMovie:
                    catalog.Add(new Content(ContentType.Movie, command.Parameters));
                    output.AppendLine("Movie added");
                    break;

                case CommandType.AddSong:
                    catalog.Add(new Content(ContentType.Song, command.Parameters));
                    output.AppendLine("Song added");
                    break;

                case CommandType.AddApplication:
                    catalog.Add(new Content(ContentType.Application, command.Parameters));
                    output.AppendLine("Application added");
                    break;

                case CommandType.Update:
                    output.AppendLine(String.Format("{0} items updated", catalog.UpdateContent(command.Parameters[0], command.Parameters[1])));
                    break;

                case CommandType.Find:
                    output.AppendLine(catalog.Find(catalog, command));
                    break;

                default:
                    throw new InvalidCastException("Unknown command!");
            }

            return output.ToString();
        }
    }
}
