using AutoWrapper.Wrappers;
using Pendulum.Identity.Domain.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Pendulum.Identity.Service.Helpers
{
    public class PasswordHelper : IPasswordHelper
    {
        private const int SaltSize = 16;

        private const int KeySize = 32;

        private const int Iterations = 10000;

        public bool PasswordChecker(string hashedPassword, string password)
        {
            var parts = hashedPassword.Split('.', 3);

            if (parts.Length != 3)
            {
                throw new ApiException("Unexpected Hash format!");
            }

            var iterations = Convert.ToInt32(parts[0]);
            var salt = Convert.FromBase64String(parts[1]);
            var key = Convert.FromBase64String(parts[2]);

            using (var algorithm = new Rfc2898DeriveBytes(
                                 password,
                                 salt,
                                 iterations,
                                 HashAlgorithmName.SHA256))
            {
                var keyToCheck = algorithm.GetBytes(KeySize);
                var verified = keyToCheck.SequenceEqual(key);

                return verified;
            }
        }

        public PasswordElements PasswordHasher(string password)
        {
            using (var algorithm = new Rfc2898DeriveBytes(
                                    password,
                                    SaltSize,
                                    Iterations,
                                    HashAlgorithmName.SHA256))
            {
                var key = Convert.ToBase64String(algorithm.GetBytes(KeySize));
                var salt = Convert.ToBase64String(algorithm.Salt);

                return new PasswordElements()
                {
                    Password = $"{Iterations}.{key}.{salt}",
                    SecurityStamp = salt
                };
            }
        }
    }
}
