namespace AutoDealer.Data.Repositories
{
    public class BaseGenericRepository
    {
        protected DataContext DbContext { get; }

        protected BaseGenericRepository(DataContext dataContext)
        {
            DbContext = dataContext;
        }
    }
}
