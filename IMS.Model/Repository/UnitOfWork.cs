using IMS.Model.Models;
using System.Threading.Tasks;

namespace IMS.Model.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _dbContext;
        private BaseRepository<Product> _products;
        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IRepository<Product> Products
        {
            get
            {
                return _products ?? (_products = new BaseRepository<Product>(_dbContext));
            }
        }
        public async Task<int> Commit()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
