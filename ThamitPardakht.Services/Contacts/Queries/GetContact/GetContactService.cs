using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThamitPardakht.Common.Utilities;
using ThamitPardakht.Data.Interface;

namespace ThamitPardakht.Services.Contacts.Queries.GetContact
{
    public class GetContactService : IGetContactService
    {
        private readonly IDataBaseContext _context;

        public GetContactService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultGetContactDto Execute(ReqhestGetContactDto contact)
        {
            var contacts = _context.Contacts.AsQueryable();
            if (!string.IsNullOrWhiteSpace(contact.SearchKey))
            {
                contacts = contacts.Where(p => p.FirstName.Contains(contact.SearchKey) && p.LastName.Contains(contact.SearchKey)
                && p.MobileNumber.Contains(contact.SearchKey));
            }
            int rowsCount = 0;
            var contactList = contacts.ToPaged(contact.Page, 20, out rowsCount).Select(p => new GetContactDto
            {
                FirstName = p.FirstName,
                LastName = p.LastName,
                Id = p.Id,
                MobileNumber = p.MobileNumber
            }).ToList();

            return new ResultGetContactDto
            {
                Rows = rowsCount,
                Contacts = contactList,
            };
        }



    }
}
