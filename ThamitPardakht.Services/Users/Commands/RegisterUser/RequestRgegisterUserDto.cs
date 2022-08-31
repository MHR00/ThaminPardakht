namespace ThamitPardakht.Services.Users.Commands.RegisterUser
{
    public class RequestRgegisterUserDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RePasword { get; set; }
        public List<RolesInRgegisterUserDto> roles { get; set; }
    }
}
