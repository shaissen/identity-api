using Pendulum.Identity.Data.Dapper;
using Pendulum.Identity.Data.Helpers;
using Pendulum.Identity.Data.Interface.QueryInterface;
using Pendulum.Identity.Domain.Constants;
using Pendulum.Identity.Domain.Enums;
using Pendulum.Identity.Domain.ViewModel;

namespace Pendulum.Identity.Data.Repository.QueryRepository
{
    public class UserManagementQuery : IUserManagementQuery
    {
        private readonly IConnectionHelper _connection;
        private readonly IDapperQuery _dapperQuery;

        public UserManagementQuery(IConnectionHelper connection, IDapperQuery dapperQuery)
        {
            _connection = connection ?? throw new ArgumentException(nameof(connection));
            _dapperQuery = dapperQuery ?? throw new ArgumentException(nameof(dapperQuery));
        }

        public Task<string> GetUserHashedPasswordByUsername(string username, ConnectionType connectionType)
            => _dapperQuery.QueryAsync<string>(_connection.GetConnection(connectionType),
                                                StoredProcedures.UserManagement.GetUserHashedPasswordByUsername,
                                                new { Username = username });

        public Task<UserInfoViewModel> GetUserInfoByUsername(string username, ConnectionType connectionType)
            => _dapperQuery.QueryAsync<UserInfoViewModel>(_connection.GetConnection(connectionType),
                                                StoredProcedures.UserManagement.GetUserInfoByUsername,
                                                new { Username = username });
    }
}
