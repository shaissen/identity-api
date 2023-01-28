using Pendulum.Identity.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pendulum.Identity.Data.Helpers
{
    public interface IConnectionHelper
    {
        string GetConnection(ConnectionType connectionType);
    }
}
