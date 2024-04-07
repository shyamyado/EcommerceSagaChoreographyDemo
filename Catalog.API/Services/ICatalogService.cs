using Catalog.API.Controllers;
using Catalog.API.Model;

namespace Catalog.API.Services
{
    public interface ICatalogService
    {
        public Task<CatalogProduct> GetCatalogById(int productId);
        public Task<List<CatalogProduct>> GetCatalog();
        public Task<CatalogProduct> AddCatalog(CatalogProduct product);
    }
}
