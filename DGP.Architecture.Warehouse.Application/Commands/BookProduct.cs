using DGP.Architecture.Warehouse.Common.Types;

namespace DGP.Architecture.Warehouse.Application.Commands
{
    public class BookProduct : ICommand
    {
        public int ProductId { get; set; }
    }
}
