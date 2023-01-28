using MediatR;
using Pendulum.Identity.Domain.DTO;
using Pendulum.Identity.Domain.Response;
using Pendulum.Identity.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pendulum.Identity.Service.Handlers.QueryHandler
{
    public class LoginHandler : IRequestHandler<LoginAdminDTO, AutoWrap>
    {
        private readonly ILoginService _login;

        public LoginHandler(ILoginService login)
        {
            this._login = login ?? throw new ArgumentNullException(nameof(login));
        }

        public Task<AutoWrap> Handle(LoginAdminDTO request, CancellationToken cancellationToken)
        {
            return _login.LoginAdmin(request);
        }
    }
}
