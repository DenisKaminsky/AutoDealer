namespace AutoDealer.Business.Functionality
{
    public abstract class BaseFunctionality
    {
        protected UnitOfWork.UnitOfWork UnitOfWork { get; }

        protected BaseFunctionality(UnitOfWork.UnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}
