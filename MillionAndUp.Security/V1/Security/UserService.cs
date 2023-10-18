using MillionAndUp.Entities.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.Security.V1.Security
{
    public class UserService : IUserService
    {

        List<UserEntity> users = new List<UserEntity>(){
            new UserEntity(){ email= "homero@gmail.com", pass="123456" },
            new UserEntity(){ email= "bart@gmail.com", pass="123456" },
};

        public bool IUser(string email, string pass)
        {
            return users.Where(d => d.email == email && d.pass == pass).Count() > 0;
        }
    }
}
