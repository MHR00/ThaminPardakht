using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThamitPardakht.Common.Dto;
using ThamitPardakht.Data.Interface;
using ThamitPardakht.Entities.Entities.Accounts;

namespace ThamitPardakht.Services.Accounts.Commands
{
    public class DispositMoneyService
    {
        private readonly IDataBaseContext _context;

        public DispositMoneyService(IDataBaseContext context)
        {
            _context = context;
        }

       

      




        public class RequestDispositMoney
        {
            public decimal Amount { get; set; }
            public MoneyType MoneyType { get; set; }
            public long userId { get; set; }
        }

        public enum MoneyType
        {
            Toman,
            Dollar
        }

        public class ResultDispositMoneyDto
        {
            public long UserId { get; set; }
        }

    }
}
