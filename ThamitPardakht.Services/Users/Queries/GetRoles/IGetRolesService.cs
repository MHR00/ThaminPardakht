using ThamitPardakht.Common.Dto;

namespace ThamitPardakht.Services.Users.Queries.GetRoles
{
    public interface IGetRolesService
    {
        ResultDto<List<RolesDto>> Execute();
    }
}