using Pendulum.Identity.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pendulum.Identity.Service.Builder
{
    public interface IEmailBuilder
    {
        string Build();

        EmailBuilder CheckIfEmailExists();

        EmailBuilder CheckIfEmailIsConfirmed();

        EmailBuilder Validate(string email, ConnectionType connectionType);
    }
}
