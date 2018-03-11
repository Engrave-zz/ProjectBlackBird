using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class UserAccess
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public int PermissionToken { get; set; }
        public Guid PersonId { get; set; }
    }
}
