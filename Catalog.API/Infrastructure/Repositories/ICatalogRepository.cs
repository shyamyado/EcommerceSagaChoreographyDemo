using Catalog.API.Model;

namespace Catalog.API.Infrastructure.Repositories
{
    public interface ICatalogRepository
    {
        public Task<CatalogProduct> GetCatalogById(int productId);
        public Task<List<CatalogProduct>> GetCatalog();
        public Task<CatalogProduct> AddCatalog(CatalogProduct product);
    }
}
