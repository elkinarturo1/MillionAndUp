using MillionAndUp.Dtos.V1;

namespace MillionAndUp.BL.V1.Services.Security
{
    public class UserService : IUserService
    {

        List<UserDto> users = new List<UserDto>()
        {
            new UserDto(){ Email= "bart@gmail.com", Pass="123" },
            new UserDto(){ Email= "lisa@gmail.com", Pass="456" },
        };

        public bool CredentialsValidation(string email, string pass)
        {
            return users.Where(d => d.Email == email && d.Pass == pass).Count() > 0;
        }
    }
}
