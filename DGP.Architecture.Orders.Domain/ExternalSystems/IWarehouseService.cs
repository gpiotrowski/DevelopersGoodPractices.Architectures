using System.Collections.Generic;

namespace DGP.Architecture.Orders.Domain.ExternalSystems
{
    public interface IWarehouseService
    {
        void BookProducts(List<int> productsIds);
    }
}