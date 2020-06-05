namespace AutoDealer.Business.Control
{
    public static class BusinessLocks
    {
        public static readonly BusinessSemaphore CarStockLock = new BusinessSemaphore(1,1);
        public static readonly BusinessSemaphore DeliveryRequestAssignmentLock = new BusinessSemaphore(1, 1);
        public static readonly BusinessSemaphore DeliveryRequestPromotionLock = new BusinessSemaphore(1, 1);
        public static readonly BusinessSemaphore OrderPromotionLock = new BusinessSemaphore(1, 1);
        public static readonly BusinessSemaphore OrderCreateLock = new BusinessSemaphore(1, 1);
    }
}
