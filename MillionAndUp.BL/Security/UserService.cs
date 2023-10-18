using MillionAndUp.Dtos;

namespace MillionAndUp.BL.Security
{
    public class UserService : IUserService
    {

        List<User> users = new List<User>(){
            new User(){ email= "homero@gmail.com", password="123456" },
            new User(){ email= "bart@gmail.com", password="123456" },
};

        public bool IUser(string email, string pass)
        {
            return users.Where(d => d.email == email && d.password == pass).Count() > 0;
        }
    }
}
