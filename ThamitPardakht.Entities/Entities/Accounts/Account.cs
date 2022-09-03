using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThamitPardakht.Entities.Entities.Commons;
using ThamitPardakht.Entities.Entities.Users;

namespace ThamitPardakht.Entities.Entities.Accounts
{
    public class Account:BaseEntity
    {
     
        public decimal BalanceT { get; set; }
        public decimal BalanceD { get; set; }
        public User User { get; set; }
        public long UserId { get; set; }

        public ICollection<Transaction> Transactions { get; set; }
    }
}
