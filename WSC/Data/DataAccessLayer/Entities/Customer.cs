using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class Customer
    {
        public Guid CustomerId { get; set; }
        public Guid PersonId { get; set; }
    }
}
