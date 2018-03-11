using System;

namespace BusinessLayer.Enumerations
{
    public enum InvoiceStatus : int
    {
        Open = 1,
        Paid = 2,
        PastDue = 3
    }
}
