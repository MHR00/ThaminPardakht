namespace ThamitPardakht.Services.Users.Queries.GetUsers
{
    public interface IGetUserServices
    {
        ResultGetUserDto Execute(RequestGetUserDto request);
    }
}