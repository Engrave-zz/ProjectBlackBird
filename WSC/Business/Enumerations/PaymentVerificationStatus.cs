using System;

namespace BusinessLayer.Enumerations
{
    public enum PaymentVerificationStatus : int
    {
        PendingVerification = 1,
        Verified = 2,
        Denied = 3
    }
}
