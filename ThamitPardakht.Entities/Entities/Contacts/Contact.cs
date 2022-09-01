using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThamitPardakht.Entities.Entities.Commons;

namespace ThamitPardakht.Entities.Entities.Contacts
{
    public  class Contact:BaseEntity
    {
       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }

        public ICollection<UserContact> UserContacts { get; set; }


    }
}
