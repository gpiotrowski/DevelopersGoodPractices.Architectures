using DGP.Architecture.Warehouse.Domain.Models;

namespace DGP.Architecture.Warehouse.Application.Services
{
    public interface IProductStockHistoryService
    {
        ProductStockHistory GetStockHistory(int productId);
    }
}