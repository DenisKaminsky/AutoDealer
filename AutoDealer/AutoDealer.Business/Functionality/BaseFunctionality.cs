namespace AutoDealer.Business.Functionality
{
    public class BaseFunctionality
    {
        protected UnitOfWork.UnitOfWork UnitOfWork { get; }

        protected BaseFunctionality(UnitOfWork.UnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}
