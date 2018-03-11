using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class Person
    {
        public Guid PersonId { get; set; }
        public string PersonFirstName { get; set; }
        public string PersonLastName { get; set; }
        public string PersonPhone { get; set; }
        public string PersonEmail { get; set; }
        public int PersonTypeId { get; set; }
    }
}
