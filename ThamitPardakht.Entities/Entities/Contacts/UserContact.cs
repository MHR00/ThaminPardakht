using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThamitPardakht.Entities.Entities.Users;

namespace ThamitPardakht.Entities.Entities.Contacts
{
    public class UserContact
    {
        public long Id { get; set; }
        public virtual User User { get; set; }
        public long UserId { get; set; }

        public virtual Contact Contact { get; set; }
        public long ContactId { get; set; }
    }
}
