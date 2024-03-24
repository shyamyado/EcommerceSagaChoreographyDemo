using Microsoft.EntityFrameworkCore;
using Stock.API.Model;

namespace Stock.API.Infrastucture.Repositories
{
    public class StockRepository : IStockRepository
    {

        private readonly StockDBContext _dbContext;

        public StockRepository(StockDBContext stockDBContext)
        {
            _dbContext = stockDBContext;
        }
        public async Task<ProductStock> AddStock(ProductStock productStock)
        {
            try
            {
                await _dbContext.ProductStocks.AddAsync(productStock);
                await _dbContext.SaveChangesAsync();
                return productStock;
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding Stock", ex);
            }
        }

        public async Task<List<ProductStock>> GetStock()
        {
            var stocks = await _dbContext.ProductStocks.ToListAsync();
            return stocks;
        }

        public async Task<ProductStock> GetStockById(int id)
        {
            ProductStock stocks = await _dbContext.ProductStocks.FirstAsync(p => p.Id == id);
            return stocks;
        }

        public async Task<ProductStock> UpdateStock(ProductStock productStock)
        {
            var stock = _dbContext.ProductStocks.FirstOrDefault(p => p.Id == productStock.Id);
            if (stock != null)
            {
                stock.Quantity += productStock.Quantity;
                _dbContext.Entry(stock).CurrentValues.SetValues(stock);
                await _dbContext.SaveChangesAsync();

            }
            return stock;
        }
    }
}
