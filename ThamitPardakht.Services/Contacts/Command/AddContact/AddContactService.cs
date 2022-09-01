using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThamitPardakht.Common.Dto;
using ThamitPardakht.Data.Interface;
using ThamitPardakht.Entities.Entities.Contacts;

namespace ThamitPardakht.Services.Contacts.Command.AddContact
{
    public class AddContactService : IAddContactService
    {
        private readonly IDataBaseContext _context;

        public AddContactService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto<ResultAddContactDto> Execute(RequestAddContactDto request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.FirstName))
                {
                    return new ResultDto<ResultAddContactDto>()
                    {
                        Data = new ResultAddContactDto()
                        {
                            ContactId = 0,
                        },
                        IsSuccess = false,
                        Message = "نام  را وارد کنید"
                    };
                }
                if (string.IsNullOrWhiteSpace(request.LastName))
                {
                    return new ResultDto<ResultAddContactDto>()
                    {
                        Data = new ResultAddContactDto()
                        {
                            ContactId = 0,
                        },
                        IsSuccess = false,
                        Message = "نام خانوادگی  را وارد کنید"
                    };
                }
                if (string.IsNullOrWhiteSpace(request.MobileNumber))
                {
                    return new ResultDto<ResultAddContactDto>()
                    {
                        Data = new ResultAddContactDto()
                        {
                            ContactId = 0,
                        },
                        IsSuccess = false,
                        Message = "شماره همراه را وارد کنید"
                    };
                }
                Contact contact = new Contact()
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    MobileNumber = request.MobileNumber,
                };
                List<UserContact> userContact = new List<UserContact>();
                foreach (var item in request.users)
                {
                    var users = _context.Users.Find(item.Id);
                    userContact.Add(new UserContact
                    {
                        Contact = contact,
                        ContactId = contact.Id,
                        User = users,
                        UserId = users.Id
                    });
                }
                contact.UserContacts = userContact;
                _context.Contacts.Add(contact);
                _context.SaveChanges();
                return new ResultDto<ResultAddContactDto>()
                {
                    Data = new ResultAddContactDto()
                    {
                        ContactId = contact.Id,
                    },
                    IsSuccess = true,
                    Message = "مخاطب جدید اضافه شد",
                };

            }
            catch (Exception)
            {

                return new ResultDto<ResultAddContactDto>()
                {
                    Data = new ResultAddContactDto()
                    {
                        ContactId = 0,
                    },
                    IsSuccess = false,
                    Message = "مخاطب اضافه نشد"
                };
            }
        }
    }
}
