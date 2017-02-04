using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogOfFreeContent.Contracts
{
    public interface ICommandExecutor
    {
        string ExecuteCommand(ICatalog contentCatalog, ICommand command);
    }
}
