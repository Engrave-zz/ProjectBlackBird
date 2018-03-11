using System;

namespace BusinessLayer.Enumerations
{
    public enum NotificationType : int
    {
        NewSale = 1,
        InvalidPayment = 2,
        MediaPull = 3,
        RestockItem = 4,
        ExpectedDelivery = 5,
        MediaSent = 6,
        InscriptionComplete = 7,
        FailedQualityControl = 8,
        WorkComplete = 9,
        EnRoute = 10,
        Delivered = 11,
        OrderComplete = 12
    }
}
