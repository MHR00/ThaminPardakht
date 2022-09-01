using ThamitPardakht.Common.Dto;

namespace ThamitPardakht.Services.Users.Commands.RegisterUser
{
    public interface IRegisterUserService
    {
        ResultDto<ResultRegisterUserDto> Execute(RequestRegisterUserDto request);
    }
}