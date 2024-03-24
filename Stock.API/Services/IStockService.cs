using Stock.API.Model;

namespace Stock.API.Services
{
    public interface IStockService
    {
        public Task<ProductStock> AddStock(ProductStock prouductStock);
        public Task<List<ProductStock>> GetStock();
        public Task<ProductStock> UpdateStock(ProductStock prouductStock);
        public Task<ProductStock> GetProductStockById(int id);
    }
}
