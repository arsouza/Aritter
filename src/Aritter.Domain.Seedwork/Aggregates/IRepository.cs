using System.Threading.Tasks;

namespace Aritter.Domain.Seedwork.Aggregates
{
    public interface IRepository
    {
        #region Methods

        int SaveChanges();

        Task<int> SaveChangesAsync();

        #endregion
    }
}
