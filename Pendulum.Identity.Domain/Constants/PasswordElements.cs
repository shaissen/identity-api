using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pendulum.Identity.Domain.Constants
{
    public class PasswordElements
    {
        public string Password { get; set; }

        public string SecurityStamp { get; set; }

        public PasswordElements()
        {
            Password = string.Empty;
            SecurityStamp = string.Empty;
        }
    }
}
