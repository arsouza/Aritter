using Aritter.Domain.Contracts;
using Aritter.Domain.UnitOfWork;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;

namespace Aritter.Infra.Data.Repository
{
    public abstract class Repository : IRepository
    {
        #region Fields

        protected readonly IUnitOfWork unitOfWork;

        #endregion Fields

        #region Constructors

        public Repository(IUnitOfWork unitOfWork)
        {
            Contract.Ensures(unitOfWork != null);
            this.unitOfWork = unitOfWork;
        }

        #endregion Constructors

        #region Methods

        public int SaveChanges()
        {
            return unitOfWork.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await unitOfWork.SaveChangesAsync();
        }

        #endregion
    }
}
