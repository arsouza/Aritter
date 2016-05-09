using System.Diagnostics.Contracts;
using System.Threading.Tasks;
using Aritter.Domain.Seedwork.Aggregates;
using Aritter.Domain.Seedwork.UnitOfWork;

namespace Aritter.Infra.Data.Seedwork.Repositories
{
    public abstract class Repository : IRepository
    {
        #region Fields

        protected readonly IUnitOfWork UnitOfWork;

        #endregion Fields

        #region Constructors

        public Repository(IUnitOfWork unitOfWork)
        {
            Contract.Ensures(unitOfWork != null);
            this.UnitOfWork = unitOfWork;
        }

        #endregion Constructors

        #region Methods

        public int SaveChanges()
        {
            return UnitOfWork.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await UnitOfWork.SaveChangesAsync();
        }

        #endregion
    }
}
