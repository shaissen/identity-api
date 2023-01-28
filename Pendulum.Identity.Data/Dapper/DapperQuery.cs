using AutoWrapper.Wrappers;
using Dapper;
using Pendulum.Identity.Domain.Constants;
using Pendulum.Identity.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Pendulum.Identity.Data.Dapper
{
    public class DapperQuery : IDapperQuery
    {
        public async Task<T> QueryAsync<T>(string connectionString, string storedProcedure = "", object? parameter = null)
        {
            try
            {
                using (var con = new SqlConnection(connectionString))
                {
                    var result = await con.QueryFirstOrDefaultAsync<T>(storedProcedure, parameter, commandType: CommandType.StoredProcedure).ConfigureAwait(false);

                    if (result == null)
                    {
                        throw new ApiException("Something went wrong", 400, CustomCodes.SqlError, string.Empty);
                    }

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new ApiException(ex.Message);
            }
        }

        public async Task<IEnumerable<T>> QueryListAsync<T>(string connectionString, string storedProcedure = "", object? parameter = null)
        {
            try
            {
                using (var con = new SqlConnection(connectionString))
                {
                    var result = await con.QueryAsync<T>(storedProcedure, parameter, commandType: CommandType.StoredProcedure).ConfigureAwait(false);

                    if (result == null)
                    {
                        throw new ApiException("Something went wrong", 400, CustomCodes.SqlError, string.Empty);
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
