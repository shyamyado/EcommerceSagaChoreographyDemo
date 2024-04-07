using Catalog.API.Model;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Infrastructure.Repositories
{
    public class CatalogRespository : ICatalogRepository
    {

        public readonly CatalogDBContext _dbContext;

        public CatalogRespository(CatalogDBContext catalogDBContext)
        {
                _dbContext = catalogDBContext;
        }
        public async Task<CatalogProduct> AddCatalog(CatalogProduct newProduct)
        {
            try
            {


                var product = new CatalogProduct
                {
                    ProductName = newProduct.ProductName,
                };

                _dbContext.CatalogProducts.Add(product);
                _dbContext.SaveChanges();
                return product;
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync($"Error occured : --------{ex}");
            }
            return null;
        }

        public async Task<List<CatalogProduct>> GetCatalog()
        {
            var catalog = await _dbContext.CatalogProducts.ToListAsync();
            return catalog;
        }

        public async Task<CatalogProduct> GetCatalogById(int productId)
        {
            if (productId <= 0)
                throw new ArgumentOutOfRangeException(nameof(productId), "Product ID must be greater than zero.");

            var catalog = await _dbContext.CatalogProducts.FirstOrDefaultAsync(x => x.ProductId == productId);
            return catalog;
        }
    }
}
