using ThamitPardakht.Common.Dto;

namespace ThamitPardakht.Services.Users.Commands.RemoveUser
{
    public interface IRemoveUserService
    {
        ResultDto Execute(long UserId);
    }
}