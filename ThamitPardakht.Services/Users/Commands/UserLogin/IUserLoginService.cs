using ThamitPardakht.Common.Dto;

namespace ThamitPardakht.Services.Users.Commands.UserLogin
{
    public interface IUserLoginService
    {
        ResultDto<ResultUserloginDto> Execute(string Username, string Password);
    }
}