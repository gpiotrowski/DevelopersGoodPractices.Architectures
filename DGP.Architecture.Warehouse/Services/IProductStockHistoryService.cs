using DGP.Architecture.Warehouse.Models;

namespace DGP.Architecture.Warehouse.Services
{
    public interface IProductStockHistoryService
    {
        ProductStockHistory GetStockHistory(int productId);
    }
}