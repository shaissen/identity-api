using Pendulum.Identity.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pendulum.Identity.Service.Builder
{
    public interface IPhoneBuilder
    {
        string Build();

        PhoneBuilder CheckIfPhoneNumberExists();

        PhoneBuilder Validate(string phoneNumber, ConnectionType connectionType);
    }
}
