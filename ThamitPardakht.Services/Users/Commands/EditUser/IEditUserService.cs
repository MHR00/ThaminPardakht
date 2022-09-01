using ThamitPardakht.Common.Dto;

namespace ThamitPardakht.Services.Users.Commands.EditUser
{
    public interface IEditUserService
    {
        ResultDto Execute(RequestEdituserDto request);
    }
}