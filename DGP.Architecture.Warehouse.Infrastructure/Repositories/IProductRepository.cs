using System.Collections.Generic;
using DGP.Architecture.Warehouse.Domain.Models;

namespace DGP.Architecture.Warehouse.Infrastructure.Repositories
{
    public interface IProductRepository
    {
        Product Get(int productId);
        void Update(Product product);
        List<Product> GetAll();
    }
}