using Pendulum.Identity.Domain.Constants;
using Pendulum.Identity.Domain.Enums;
using Pendulum.Identity.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pendulum.Identity.Service.Helpers
{
    public interface IJwtHelper
    {
        Task<JwtElements> GenerateJwtToken(UserInfoViewModel userInfo);

        Task AddRefreshToken(Guid? userId, string token, ConnectionType connectionType);

    }
}
