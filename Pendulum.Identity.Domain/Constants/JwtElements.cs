using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pendulum.Identity.Domain.Constants
{
    public class JwtElements
    {
        public string Token { get; set; }

        public string TokenType { get; set; }

        public string RefreshToken { get; set; }

        public JwtElements()
        {
            Token = string.Empty;
            TokenType = string.Empty;
            RefreshToken = string.Empty;
        }
    }
}
