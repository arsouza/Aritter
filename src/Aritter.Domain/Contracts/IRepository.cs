using System.Threading.Tasks;

namespace Aritter.Domain.Contracts
{
    public interface IRepository
    {
        #region Methods

        int SaveChanges();

        Task<int> SaveChangesAsync();

        #endregion
    }
}
