using System;

namespace BusinessLayer.Enumerations
{
    public enum OrderStatus : int
    {
        Submitted = 1,
        FailedValidation = 2,
        WorkComplete = 3,
        Delivered = 4,
        EnRoute = 5,
        Complete = 6,
        None = 7
    }
}
