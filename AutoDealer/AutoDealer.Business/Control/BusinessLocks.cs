namespace AutoDealer.Business.Control
{
    public static class BusinessLocks
    {
        public static readonly object CarStockLock = new object();
    }
}
