using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ThamitPardakht.Services.Contacts.Command.AddContact;
using ThamitPardakht.Services.Contacts.Queries.GetContact;

namespace ThamitPardakht.EndPoint.Controllers
{
    public class ContactController : Controller
    {
        private readonly IAddContactService _addContactService;
        private readonly IGetContactService _getContactService;

        public ContactController(IAddContactService addContactService,
            IGetContactService getContactService)
        {
            _addContactService = addContactService;
            _getContactService = getContactService;
        }
        public IActionResult Index(string seachKey, int page = 1)
        {
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            long UserId = (long)Convert.ToDouble(user);
            if(user == null)
            {
                return NotFound();
            }
            return View(_getContactService.Execute(new RequestGetContactDto
            {
                SearchKey = seachKey,
                Page = page
            }, UserId));
        }

        [HttpGet]
        public IActionResult AddContact()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult AddContact(string FirstName , string LastName , string MobileNumber) 
        {


            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            long UserId = (long)Convert.ToDouble(userId);
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
