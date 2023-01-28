using AutoWrapper.Wrappers;
using Pendulum.Identity.Data.Interface;
using Pendulum.Identity.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pendulum.Identity.Service.Builder
{
    public class EmailBuilder : IEmailBuilder
    {
        private string _email;

        private ConnectionType _connectionType;

        private readonly IAccountValidator _accountValidator;

        public EmailBuilder(IAccountValidator accountValidator)
        {
            this._accountValidator = accountValidator ?? throw new ArgumentNullException(nameof(accountValidator)); 
        }

        public string Build()
        {
            return _email;
        }

        public EmailBuilder CheckIfEmailExists()
        {
            if (!_accountValidator.CheckIfEmailExists(_email, _connectionType).GetAwaiter().GetResult())
            {
                throw new ApiException("Email Address does not exists!", 400);
            }

            return this;
        }

        public EmailBuilder CheckIfEmailIsConfirmed()
        {
            throw new NotImplementedException();
        }

        public EmailBuilder Validate(string email, ConnectionType connectionType)
        {
            _email = email;
            _connectionType = connectionType;
            return this;
        }
    }
}
