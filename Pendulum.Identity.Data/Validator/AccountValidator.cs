using Pendulum.Identity.Data.Dapper;
using Pendulum.Identity.Data.Helpers;
using Pendulum.Identity.Domain.Constants;
using Pendulum.Identity.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pendulum.Identity.Data.Interface
{
    public class AccountValidator : IAccountValidator
    {
        private readonly IDapperQuery _dapperQuery;
        private readonly IConnectionHelper _connection;
        public AccountValidator(IDapperQuery dapperQuery, IConnectionHelper connection)
        {
            this._dapperQuery = dapperQuery ?? throw new ArgumentNullException(nameof(DapperQuery));
            this._connection = connection ?? throw new ArgumentNullException(nameof(connection));
        }
        public async Task<bool> CheckIfEmailExists(string email, ConnectionType connectionType)
            => await GetAccountValidation(StoredProcedures.Validations.CheckIfEmailExists, new { EmailAddress = email }, connectionType);

        public async Task<bool> CheckIfPhoneNumberExists(string phoneNumber, ConnectionType connectionType)
            => await GetAccountValidation(StoredProcedures.Validations.CheckIfEmailExists, new { PhoneNumber = phoneNumber }, connectionType);


        public Task<bool> GetAccountValidation(string storedProcedure, object parameter, ConnectionType connectionType)
        {
            return this._dapperQuery.QueryAsync<bool>(_connection.GetConnection(connectionType), storedProcedure, parameter);
        }
    }
}
