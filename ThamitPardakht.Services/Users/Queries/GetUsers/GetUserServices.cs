using ThamitPardakht.Common.Utilities;
using ThamitPardakht.Data.Interface;

namespace ThamitPardakht.Services.Users.Queries.GetUsers
{
    public class GetUserServices : IGetUserServices
    {
        private readonly IDataBaseContext _context;

        public GetUserServices(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultGetUserDto Execute(RequestGetUserDto request)
        {
            var users = _context.Users.AsQueryable();
            if (!string.IsNullOrWhiteSpace(request.SearchKey))
            {
                users = users.Where(p => p.FullName.Contains(request.SearchKey) && p.Email.Contains(request.SearchKey));
            }
            int rowsCount = 0;
            var userList = users.ToPaged(request.Page, 20, out rowsCount).Select(p => new GetUserDto
            {
                Email = p.Email,
                FullName = p.FullName,
                Id = p.Id
            }).ToList();
            return new ResultGetUserDto
            {
                Rows = rowsCount,
                Users = userList,
            };
        }
    }
}
