using Pendulum.Identity.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pendulum.Identity.Data.Interface
{
    public interface IAccountValidator
    {
        Task<bool> CheckIfEmailExists(string email, ConnectionType connectionType);

        Task<bool> CheckIfPhoneNumberExists(string phoneNumber, ConnectionType connectionType);
    }
}
