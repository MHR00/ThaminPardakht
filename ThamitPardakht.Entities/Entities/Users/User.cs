using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThamitPardakht.Entities.Entities.Commons;

namespace ThamitPardakht.Entities.Entities.Users
{
    public  class User : BaseEntity
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public ICollection<UserInRole> UserInRole { get; set; }
    }
}
