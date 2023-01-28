using Microsoft.Extensions.DependencyInjection;
using Pendulum.Identity.Data.Dapper;
using Pendulum.Identity.Data.Helpers;
using Pendulum.Identity.Data.Interface;
using Pendulum.Identity.Data.Interface.CommandInterface;
using Pendulum.Identity.Data.Interface.QueryInterface;
using Pendulum.Identity.Data.Repository.CommandRepository;
using Pendulum.Identity.Data.Repository.QueryRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pendulum.Identity.Data.Dependency
{
    public static class DataDependency
    {
        public static void AddDataDependency(this IServiceCollection service)
        {
            #region Query
            service.AddScoped<IRefreshTokenQuery, RefreshTokenQuery>();
            service.AddScoped<IUserManagementQuery, UserManagementQuery>();
            #endregion

            #region Command
            service.AddScoped<IRefreshTokenCommand, RefreshTokenCommand>();
            #endregion

            #region Dapper
            service.AddScoped<IDapperQuery, DapperQuery>();
            service.AddScoped<IDapperCommand, DapperCommand>();
            #endregion

            #region Helper
            service.AddScoped<IConnectionHelper, ConnectionHelper>();
            #endregion

            #region Validator
            service.AddScoped<IAccountValidator, AccountValidator>();
            #endregion
        }
    }
}
