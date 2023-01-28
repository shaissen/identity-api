using Pendulum.Identity.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pendulum.Identity.Data.Dapper
{
    public interface IDapperQuery
    {
        Task<T> QueryAsync<T>(string connectionString, string storedProcedure = "", object? parameter = null);

        Task<IEnumerable<T>> QueryListAsync<T>(string connectionString, string storedProcedure = "", object? parameter = null);
    }
}
