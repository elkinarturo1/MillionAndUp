using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.Security.V1.Security
{
    public interface IUserService
    {
        public bool IUser(string email, string pass);
    }
}
