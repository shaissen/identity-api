using Pendulum.Identity.Domain.Constants;
using Pendulum.Identity.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pendulum.Identity.Data.Interface.CommandInterface
{
    public interface IRefreshTokenCommand
    {
        Task<bool> InsertRefreshToken(RefreshTokenElements refreshToken, ConnectionType connection);

        Task<bool> UpdateRefreshToken(RefreshTokenElements refreshToken, ConnectionType connection);
    }
}
