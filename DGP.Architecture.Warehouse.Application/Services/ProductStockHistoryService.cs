using System;
using System.Linq;
using DGP.Architecture.Warehouse.Domain.Models;

namespace DGP.Architecture.Warehouse.Application.Services
{
    public class ProductStockHistoryService : IProductStockHistoryService
    {
        private Random _random = new Random();
        public ProductStockHistory GetStockHistory(int productId)
        {
            return new ProductStockHistory()
            {
                ProductId = productId,
                StockHistory = Enumerable.Range(0, _random.Next(1, 15)).Select(_ => new ProductStockHistory.StockHistoryRecord()
                {
                    DateTime = GenerateRandomDate(),
                    AvailableQuantity = _random.Next(0, 1000)
                }).ToList()
            };
        }

        private DateTime GenerateRandomDate()
        {
            DateTime start = new DateTime(2000, 1, 1);
            int range = (DateTime.Today - start).Days;

            return start.AddDays(_random.Next(range));
        }
    }
}