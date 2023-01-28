using Pendulum.Identity.Domain.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pendulum.Identity.Service.Helpers
{
    public interface IPasswordHelper
    {
        PasswordElements PasswordHasher(string password);

        bool PasswordChecker(string hashedPassword, string password);
    }
}
