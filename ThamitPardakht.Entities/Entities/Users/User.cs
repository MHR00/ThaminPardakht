using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThamitPardakht.Entities.Entities.Accounts;
using ThamitPardakht.Entities.Entities.Commons;
using ThamitPardakht.Entities.Entities.Contacts;

namespace ThamitPardakht.Entities.Entities.Users
{
    public  class User : BaseEntity
    {
      
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public Account Account { get; set; }
        public long AccountId { get; set; }
        public ICollection<UserInRole> UserInRoles { get; set; }
        public ICollection<UserContact> UserContacts { get; set; }
    }
}
