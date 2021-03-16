using System;
using System.Collections.Generic;

namespace DGP.Architecture.Warehouse.Domain.Models
{
    public class ProductStockHistory
    {
        public int ProductId { get; set; }
        public List<StockHistoryRecord> StockHistory{ get; set; }

        public class StockHistoryRecord
        {
            public DateTime DateTime { get; set; }
            public int AvailableQuantity { get; set; }
        }
    }
}