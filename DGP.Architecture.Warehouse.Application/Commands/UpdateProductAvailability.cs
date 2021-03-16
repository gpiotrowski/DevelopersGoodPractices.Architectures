using DGP.Architecture.Warehouse.Common.Types;

namespace DGP.Architecture.Warehouse.Application.Commands
{
    public class UpdateProductAvailability : ICommand
    {
        public int ProductId { get; set; }
        public int AvailableQuantity { get; set; }

    }
}
