using Pendulum.Identity.Data.Dapper;
using Pendulum.Identity.Data.Helpers;
using Pendulum.Identity.Data.Interface.CommandInterface;
using Pendulum.Identity.Domain.Constants;
using Pendulum.Identity.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pendulum.Identity.Data.Repository.CommandRepository
{
    public class RefreshTokenCommand : IRefreshTokenCommand
    {
        private readonly IDapperCommand _dapper;
        private readonly IConnectionHelper _connection;

        public RefreshTokenCommand(IDapperCommand dapper, IConnectionHelper connection)
        {
            this._dapper = dapper ?? throw new ArgumentNullException(nameof(dapper));
            this._connection = connection ?? throw new ArgumentNullException(nameof(connection));
        }
        public Task<bool> InsertRefreshToken(RefreshTokenElements refreshToken, ConnectionType connectionType)
            => _dapper.ActionAsync(_connection.GetConnection(connectionType),
                  StoredProcedures.TokenManagement.InsertRefreshToken,
                  new
                  {
                      UserId = refreshToken.UserId,
                      Token = refreshToken.Token
                  });


        public Task<bool> UpdateRefreshToken(RefreshTokenElements refreshToken, ConnectionType connectionType)
           => _dapper.ActionAsync(_connection.GetConnection(connectionType),
                  StoredProcedures.TokenManagement.UpdateRefreshToken,
                  new
                  {
                      UserId = refreshToken.UserId,
                      Token = refreshToken.Token
                  });
    }
}
