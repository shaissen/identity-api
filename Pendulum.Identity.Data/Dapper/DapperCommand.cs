using AutoWrapper.Wrappers;
using Dapper;
using Pendulum.Identity.Domain.Constants;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pendulum.Identity.Data.Dapper
{
    public class DapperCommand : IDapperCommand
    {
        public async Task<bool> ActionAsync(string connectionString, string storedProcedure, object parameter)
        {
			try
			{
				using (var connection = new SqlConnection(connectionString))
				{
					var result = Convert.ToBoolean(await connection.ExecuteAsync(storedProcedure, parameter, commandType: CommandType.StoredProcedure).ConfigureAwait(false));

					if (!result)
					{
						throw new ApiException("Something went wrong!", 400, CustomCodes.SqlError, string.Empty);
					}

					return result;
				}
			}
			catch (Exception ex)
			{

				throw new ApiException(ex.Message);
			}
        }
    }
}
