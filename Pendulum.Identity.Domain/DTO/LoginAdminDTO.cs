using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pendulum.Identity.Domain.DTO
{
    public class LoginAdminDTO : IRequest<AutoWrap>
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
