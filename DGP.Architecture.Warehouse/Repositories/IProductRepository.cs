using System.Collections.Generic;
using DGP.Architecture.Warehouse.Models;

namespace DGP.Architecture.Warehouse.Repositories
{
    public interface IProductRepository
    {
        Product Get(int productId);
        void Update(Product product);
        List<Product> GetAll();
    }
}