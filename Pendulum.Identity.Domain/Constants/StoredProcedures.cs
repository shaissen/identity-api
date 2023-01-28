using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pendulum.Identity.Domain.Constants
{
    public static class StoredProcedures
    {
        public static class Validations
        {
            public const string CheckIfEmailExists = "sp_CheckIfEmailExists";
            public const string CheckIfPhoneNumberExists = "sp_CheckIfPhoneNumberExists";
        }

        public static class UserManagement
        {
            public const string GetUserHashedPasswordByUsername = "sp_GetUserHashedPasswordByUsername";
            public const string GetUserInfoByUsername = "sp_GetUserInfoByUsername";
        }

        public static class TokenManagement
        {
            public const string GetRefreshTokenByUserId = "sp_GetRefreshTokenByUserId";
            public const string InsertRefreshToken = "sp_InsertRefreshToken";
            public const string UpdateRefreshToken = "sp_UpdateRefreshToken";
        }
    }
}
