using ThamitPardakht.Common.Dto;

namespace ThamitPardakht.Services.Users.Commands.RegisterUser
{
    public interface IRegisterUserService
    {
        ResultDto<ResultRgegisterUserDto> Execute(RequestRgegisterUserDto request);
    }
}