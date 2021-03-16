using System.Collections.Generic;
using System.Linq;
using DGP.Architecture.Warehouse.Domain.Models;

namespace DGP.Architecture.Warehouse.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> _products;

        public ProductRepository()
        {
            _products = new List<Product>()
            {
                new Product()
                {
                    Id = 1,
                    AvailableQuantity = 10
                },
                new Product()
                {
                    Id = 2,
                    AvailableQuantity = 20
                },
                new Product()
                {
                    Id = 3,
                    AvailableQuantity = 30
                }
            };
        }

        public Product Get(int productId)
        {
            return _products.Single(x => x.Id == productId);
        }

        public void Update(Product product)
        {
            // Simulate "update"
            var productToRemove = _products.Single(x => x.Id == product.Id);
            _products.Remove(productToRemove);

            _products.Add(product);
        }

        public List<Product> GetAll()
        {
            return _products;
        }
    }
}