using Stock.API.Infrastucture.Repositories;
using Stock.API.Model;

namespace Stock.API.Services
{
    public class StockService : IStockService
    {

        private readonly IStockRepository _stockRepository;

        public StockService(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }
        public async Task<ProductStock> AddStock(ProductStock prouductStock)
        {
            var product = await _stockRepository.AddStock(prouductStock);
            return product;
        }

        public async Task<ProductStock> GetProductStockById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProductStock>> GetStock()
        {
            var stocks = await _stockRepository.GetStock();
            return stocks;
        }

        public Task<ProductStock> UpdateStock(ProductStock prouductStock)
        {
            var stock = _stockRepository.UpdateStock(prouductStock);
            return stock;
        }
    }
}
