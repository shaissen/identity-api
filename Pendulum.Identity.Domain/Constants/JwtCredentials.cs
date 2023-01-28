using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pendulum.Identity.Domain.Constants
{
    public class JwtCredentials
    {
        public string Issuer { get; set; }

        public string Audience { get; set; }

        public string Key { get; set; }

        public JwtCredentials()
        {
            Issuer = string.Empty;
            Audience = string.Empty;
            Key = string.Empty;
        }
    }
}
