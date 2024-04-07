using Catalog.API.Infrastructure.Repositories;
using Catalog.API.Model;

namespace Catalog.API.Services
{
    public class CatalogService : ICatalogService
    {
        public readonly ICatalogRepository _catalogRepository;

        public CatalogService(ICatalogRepository catalogRepository)
        {
                _catalogRepository = catalogRepository ?? throw new ArgumentNullException(nameof(catalogRepository));
        }
        public async Task<CatalogProduct> AddCatalog(CatalogProduct product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product), "Product cannot be null.");

            try
            {
                var addedProduct = await _catalogRepository.AddCatalog(product);
                return addedProduct;
            }
            catch (Exception ex)
            {

                throw new Exception("Unable to add new product.", ex);
            }
        }

        public async Task<List<CatalogProduct>> GetCatalog()
        {
            try
            {
                var catalog = await _catalogRepository.GetCatalog();
                return catalog;
            }
            catch (Exception ex)
            {

                throw new Exception("Error occurred while retrieving catalog.", ex);
            }
        }

        public async Task<CatalogProduct> GetCatalogById(int productId)
        {
            if (productId <= 0)
                throw new ArgumentException("Product ID must be greater than zero.", nameof(productId));

            try
            {
                var product = await _catalogRepository.GetCatalogById(productId);
                return product;
            }
            catch (Exception ex)
            {

                throw new Exception($"Error occurred while retrieving product with ID {productId}. " , ex);
            }
        }
    }
}
