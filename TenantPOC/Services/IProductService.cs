using TenantPOC.Models;
using TenantPOC.Services.Models;

namespace TenantPOC.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> CreateProduct(CreateProductModel createProductModel);
        Task<bool> DeleteProduct(int id);
    }
}
