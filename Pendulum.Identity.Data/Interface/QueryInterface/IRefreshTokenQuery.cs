using Pendulum.Identity.Domain.Constants;
using Pendulum.Identity.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pendulum.Identity.Data.Interface.QueryInterface
{
    public interface IRefreshTokenQuery
    {
        Task<RefreshTokenElements> GetRefreshTokenByUserId(Guid? userId, ConnectionType connectionType);
    }
}
