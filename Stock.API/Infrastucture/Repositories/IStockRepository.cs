using Stock.API.Model;

namespace Stock.API.Infrastucture.Repositories
{
    public interface IStockRepository
    {
        public Task<List<ProductStock>> GetStock();
        public Task<ProductStock> GetStockById(int id);
        public Task<ProductStock> AddStock(ProductStock productStock);
        public Task<ProductStock> UpdateStock(ProductStock productStock);

    }
}
