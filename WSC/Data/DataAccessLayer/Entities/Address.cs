using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class Address
    {
        public Guid AddressId { get; set; }
        public Guid PersonId { get; set; }
        public int StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string AddressCity { get; set; }
        public string AddressState { get; set; }
        public string AddressZip { get; set; }
        public int AddressTypeId { get; set; }
    }
}
