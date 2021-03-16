using System.Collections.Generic;
using DGP.Architecture.Warehouse.Infrastructure.ReadModels;

namespace DGP.Architecture.Warehouse.Infrastructure.Repositories
{
    public interface IProductsAvailabilityReportReadModelRepository
    {
        ProductAvailabilityReportReadModel Get(int productId);
        void Update(ProductAvailabilityReportReadModel readModel);
        List<ProductAvailabilityReportReadModel> GetAll();
    }
}