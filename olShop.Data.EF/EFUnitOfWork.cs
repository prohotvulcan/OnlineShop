using olShop.Data.EF.EFContext;
using olShop.Infrastructure.Interfaces;

namespace olShop.Data.EF
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly OlShopDbContext _dbContext;

        public EFUnitOfWork(OlShopDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
