using Microsoft.Extensions.Options;
using Pendulum.Identity.Domain.Constants;
using Pendulum.Identity.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pendulum.Identity.Data.Helpers
{
    public class ConnectionHelper : IConnectionHelper
    {
        private readonly IOptions<ConnectionStrings> _connectionString;

        public ConnectionHelper(IOptions<ConnectionStrings> connectionStrings)
        {
            this._connectionString = connectionStrings ?? throw new ArgumentNullException(nameof(connectionStrings));
        }

        public string GetConnection(ConnectionType connectionType)
        {
            var connectionString = string.Empty;

            switch (connectionType)
            {
                case ConnectionType.Admin:
                    connectionString = _connectionString.Value.AdminConnection;
                    break;
                default:
                    connectionString = string.Empty;
                    break;
            }

            return connectionString;
        }
    }
}
