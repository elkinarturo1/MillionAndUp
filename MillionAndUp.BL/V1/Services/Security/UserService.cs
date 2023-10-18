using MillionAndUp.Dtos.V1;

namespace MillionAndUp.BL.V1.Services.Security
{
    public class UserService : IUserService
    {

        List<UserDto> users = new List<UserDto>(){
            new UserDto(){ email= "homero@gmail.com", pass="123" },
            new UserDto(){ email= "bart@gmail.com", pass="456" },
};

        public bool CredentialsValidation(string email, string pass)
        {
            return users.Where(d => d.email == email && d.pass == pass).Count() > 0;
        }
    }
}
