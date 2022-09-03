using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThamitPardakht.Entities.Entities.Commons;
using ThamitPardakht.Entities.Entities.Users;

namespace ThamitPardakht.Entities.Entities.Accounts
{
    public class Transaction:BaseEntity
    {
        public long SenderId { get; set; }
        public long ReciverId { get; set; }
        public decimal Money { get; set; }
        public MoneyType MoneyType { get; set; }

        public TransactionType TransferType { get; set; }
        public Account Account { get; set; }
        public long AccountId { get; set; }
    }



    public enum MoneyType
    {
        Toman,
        Dollar
    }

    public enum TransactionType
    {
        Deposit,
        Withdraw,
    }
}
