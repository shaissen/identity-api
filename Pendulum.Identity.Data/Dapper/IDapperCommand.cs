using Pendulum.Identity.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pendulum.Identity.Data.Dapper
{
    public interface IDapperCommand
    {
        Task<bool> ActionAsync(string connectionString, string storedProcedure, object parameter);
    }
}
