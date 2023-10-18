using Autofac;
using MillionAndUp.Security.V1.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.Security.V1
{
    public class Module : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            RegisterRepositories(builder);
        }

        private static void RegisterRepositories(ContainerBuilder builder)
        {
            builder.RegisterType<UserService>().As<IUserService>();
        }
    }
}
