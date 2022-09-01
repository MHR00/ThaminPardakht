
using Microsoft.AspNetCore.Mvc;
using ThamitPardakht.Services.Contacts.Command.AddContact;

namespace ThamitPardakht.EndPoint.Controllers
{
    public class ContactController : Controller
    {
        private readonly IAddContactService _addContactService;

        public ContactController(IAddContactService addContactService)
        {
            _addContactService = addContactService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddContact(string FirstName , string LastName , string MobileNumber , long UserId) 
        {
            var result = _addContactService.Execute(new RequestAddContactDto
            {
                FirstName = FirstName ,
                LastName = LastName ,
                users = new List<UserContactDto>()
                {
                    new UserContactDto()
                    {
                        Id = UserId
                    }
                },
                MobileNumber = MobileNumber ,
            });
            return Json(result);
        }
    }
}
