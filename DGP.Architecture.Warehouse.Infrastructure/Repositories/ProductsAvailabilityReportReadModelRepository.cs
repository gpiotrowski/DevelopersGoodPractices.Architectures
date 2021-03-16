using System.Collections.Generic;
using System.Linq;
using DGP.Architecture.Warehouse.Infrastructure.ReadModels;

namespace DGP.Architecture.Warehouse.Infrastructure.Repositories
{
    public class ProductsAvailabilityReportReadModelRepository : IProductsAvailabilityReportReadModelRepository
    {
        private readonly List<ProductAvailabilityReportReadModel> _productsAvailabilityReportReadModel;

        public ProductsAvailabilityReportReadModelRepository()
        {
            _productsAvailabilityReportReadModel = new List<ProductAvailabilityReportReadModel>();
        }

        public ProductAvailabilityReportReadModel Get(int productId)
        {
            var readModel = _productsAvailabilityReportReadModel.SingleOrDefault(x => x.ProductId == productId);

            return readModel;
        }

        public List<ProductAvailabilityReportReadModel> GetAll()
        {
            return _productsAvailabilityReportReadModel;
        }

        public void Update(ProductAvailabilityReportReadModel readModel)
        {
            // Simulate "update"
            var readModelToRemove = _productsAvailabilityReportReadModel.SingleOrDefault(x => x.ProductId == readModel.ProductId);
            if (readModelToRemove != null)
            {
                _productsAvailabilityReportReadModel.Remove(readModelToRemove);
            }

            _productsAvailabilityReportReadModel.Add(readModel);
        }
    }
}
