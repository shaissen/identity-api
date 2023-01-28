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
    public class PhoneBuilder : IPhoneBuilder
    {
        private string _phoneNumber;

        private ConnectionType _connectionType;

        private readonly IAccountValidator _accountValidator;

        public PhoneBuilder(IAccountValidator accountValidator)
        {
            this._accountValidator = accountValidator ?? throw new ArgumentNullException(nameof(_accountValidator));
        }

        public string Build()
        {
            return _phoneNumber;
        }

        public PhoneBuilder CheckIfPhoneNumberExists()
        {
            if (!_accountValidator.CheckIfPhoneNumberExists(_phoneNumber, _connectionType).GetAwaiter().GetResult())
            {
                throw new ApiException("Phone Number does not exists!", 400);
            }

            return this;
        }

        public PhoneBuilder Validate(string phoneNumber, ConnectionType connectionType)
        {
            _phoneNumber = phoneNumber;
            _connectionType = connectionType;
            return this;
        }
    }
}
