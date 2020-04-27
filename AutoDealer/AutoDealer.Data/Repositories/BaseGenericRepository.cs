namespace AutoDealer.Data.Repositories
{
    public abstract class BaseGenericRepository
    {
        protected DataContext DbContext { get; }

        protected BaseGenericRepository(DataContext dataContext)
        {
            DbContext = dataContext;
        }
    }
}
