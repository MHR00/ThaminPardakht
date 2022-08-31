using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThamitPardakht.Common.Dto;
using ThamitPardakht.Common.Utilities;
using ThamitPardakht.Data.Interface;
using ThamitPardakht.Entities.Entities.Users;

namespace ThamitPardakht.Services.Users.Commands.RegisterUser
{
    public class RegisterUserService : IRegisterUserService
    {
        private readonly IDataBaseContext _context;

        public RegisterUserService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto<ResultRgegisterUserDto> Execute(RequestRgegisterUserDto request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.Email))
                {
                    return new ResultDto<ResultRgegisterUserDto>()
                    {
                        Data = new ResultRgegisterUserDto()
                        {
                            UserId = 0,
                        },
                        IsSuccess = false,
                        Message = "پست الکترونیک را وارد نمایید",
                    };
                }

                if (string.IsNullOrWhiteSpace(request.FullName))
                {
                    return new ResultDto<ResultRgegisterUserDto>()
                    {
                        Data = new ResultRgegisterUserDto()
                        {
                            UserId = 0,
                        },
                        IsSuccess = false,
                        Message = "نام را وارد کنید",
                    };
                }
                if (string.IsNullOrWhiteSpace(request.Password))
                {
                    return new ResultDto<ResultRgegisterUserDto>()
                    {
                        Data = new ResultRgegisterUserDto()
                        {
                            UserId = 0,
                        },
                        IsSuccess = false,
                        Message = "رمز عبور رو وارد کنید"
                    };
                }
                if (request.Password != request.RePasword)
                {
                    return new ResultDto<ResultRgegisterUserDto>()
                    {
                        Data = new ResultRgegisterUserDto()
                        {
                            UserId = 0,
                        },
                        IsSuccess = false,
                        Message = "رمز عبور و تکرار آن برابر نیست"
                    };
                }
                User user = new User()
                {
                    Email = request.Email,
                    FullName = request.FullName,
                    Password = HashPassword.GetSha256Hash(request.Password),
                };
                List<UserInRole> userInRoles = new List<UserInRole>();
                foreach (var item in request.roles)
                {
                    var roles = _context.Roles.Find(item.Id);
                    userInRoles.Add(new UserInRole
                    {
                        Role = roles,
                        RoleId = roles.Id,
                        User = user,
                        UserId = user.Id,
                    });
                }
                user.UserInRole = userInRoles;

                _context.Users.Add(user);
                _context.SaveChanges();
                return new ResultDto<ResultRgegisterUserDto>()
                {
                    Data = new ResultRgegisterUserDto()
                    {
                        UserId = user.Id,
                    },
                    IsSuccess = true,
                    Message = "ثبت نام کاربر انجام شد",
                };
            }
            catch (Exception)
            {

                return new ResultDto<ResultRgegisterUserDto>()
                {
                    Data = new ResultRgegisterUserDto()
                    {
                        UserId = 0,

                    },
                    IsSuccess = false,
                    Message = "ثبت نام انجام نشد !"
                };
            }




        }
    }
}
