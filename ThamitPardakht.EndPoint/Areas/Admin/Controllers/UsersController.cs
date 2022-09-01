using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ThamitPardakht.Services.Users.Commands.EditUser;
using ThamitPardakht.Services.Users.Commands.RegisterUser;
using ThamitPardakht.Services.Users.Commands.RemoveUser;
using ThamitPardakht.Services.Users.Queries.GetRoles;
using ThamitPardakht.Services.Users.Queries.GetUsers;

namespace ThamitPardakht.EndPoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly IGetUserServices _getUserServices;
        private readonly IGetRolesService _getRolesService;
        private readonly IRegisterUserService _registerUserService;
        private readonly IRemoveUserService _removeUserService;
        private readonly IEditUserService _editUserService;

        public UsersController(IGetUserServices getUserServices,
            IGetRolesService getRolesService,
            IRegisterUserService registerUserService,
            IRemoveUserService removeUserService,
            IEditUserService editUserService)
        {
            _getUserServices = getUserServices;
            _getRolesService = getRolesService;
            _registerUserService = registerUserService;
            _removeUserService = removeUserService;
            _editUserService = editUserService;
        }


      
        public IActionResult Index(string seachKey , int page=1)
        {
            return View(_getUserServices.Execute(new RequestGetUserDto
            {
                Page = page,
                SearchKey = seachKey,
            }));
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Roles = new SelectList(_getRolesService.Execute().Data, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(string Email , string FullName , long RoleId , string Password , string RePassword)
        {
            var result = _registerUserService.Execute(new RequestRegisterUserDto
            {
                Email = Email,
                FullName = FullName,
                roles = new List<RolesInRegisterUserDto>()
                {
                    new RolesInRegisterUserDto
                    {
                        Id = RoleId
                    }
                },
                Password = Password,
                RePasword = RePassword,
            });
            return Json(result);
        }

        [HttpPost]
        public IActionResult Delete(long UserId)
        {
            return Json(_removeUserService.Execute(UserId));
        }

        [HttpPost]
        public IActionResult Edit(long UserId , string FullName)
        {
            return Json(_editUserService.Execute(new RequestEdituserDto
            {
                Fullname = FullName,
                UserId = UserId,
            }));
        }


    }
}
