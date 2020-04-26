using System.Threading.Tasks;

namespace AutoDealer.Business.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task BeginTransactionAsync();

        Task CommitAsync();

        Task RollbackAsync();
    }
}
