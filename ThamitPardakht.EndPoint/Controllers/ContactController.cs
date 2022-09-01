
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
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
