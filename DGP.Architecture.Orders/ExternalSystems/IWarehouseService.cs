using System.Collections.Generic;

namespace DGP.Architecture.Orders.ExternalSystems
{
    public interface IWarehouseService
    {
        void BookProducts(List<int> productsIds);
    }
}