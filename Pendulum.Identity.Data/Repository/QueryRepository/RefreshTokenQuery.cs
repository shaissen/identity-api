using Pendulum.Identity.Data.Dapper;
using Pendulum.Identity.Data.Helpers;
using Pendulum.Identity.Data.Interface.QueryInterface;
using Pendulum.Identity.Domain.Constants;
using Pendulum.Identity.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pendulum.Identity.Data.Repository.QueryRepository
{
    public class RefreshTokenQuery : IRefreshTokenQuery
    {
        private readonly IDapperQuery _dapperQuery;
        private readonly IConnectionHelper _connection;

        public RefreshTokenQuery(IDapperQuery dapperQuery, IConnectionHelper connection)
        {
            this._dapperQuery = dapperQuery ?? throw new ArgumentNullException(nameof(dapperQuery));
            this._connection = connection ?? throw new ArgumentNullException(nameof(connection));
        }

        public Task<RefreshTokenElements> GetRefreshTokenByUserId(Guid? userId, ConnectionType connectionType)
            => _dapperQuery.QueryAsync<RefreshTokenElements>(_connection.GetConnection(connectionType), StoredProcedures.TokenManagement.GetRefreshTokenByUserId,
                                                            new { UserId = userId });
    }
}
