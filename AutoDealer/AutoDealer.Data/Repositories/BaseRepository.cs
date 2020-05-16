namespace AutoDealer.Data.Repositories
{
    public abstract class BaseRepository
    {
        protected DataContext DbContext { get; }

        protected BaseRepository(DataContext dataContext)
        {
            DbContext = dataContext;
        }
    }
}
