namespace AutoDealer.Business.Control
{
    public static class BusinessLocks
    {
        public static readonly BusinessSemaphore CarStockLock = new BusinessSemaphore(1,1);
    }
}
