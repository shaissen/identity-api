using AutoWrapper.Wrappers;
using Pendulum.Identity.Data.Interface.QueryInterface;
using Pendulum.Identity.Domain.Constants;
using Pendulum.Identity.Domain.DTO;
using Pendulum.Identity.Domain.Enums;
using Pendulum.Identity.Domain.Response;
using Pendulum.Identity.Domain.ViewModel;
using Pendulum.Identity.Service.Builder;
using Pendulum.Identity.Service.Helpers;
using Pendulum.Identity.Service.Interface;

namespace Pendulum.Identity.Service.Services.QueryService
{
    public class LoginService : ILoginService
    {
        private readonly IEmailBuilder _emailValidator;
        private readonly IPhoneBuilder _phoneValidator;
        private readonly IUserManagementQuery _user;
        private readonly IPasswordHelper _password;
        private readonly IJwtHelper _jwt;

        public LoginService(IEmailBuilder emailValidator, IPhoneBuilder phoneValidator, IUserManagementQuery user,
                            IPasswordHelper password, IJwtHelper jwt)
        {
            _emailValidator = emailValidator ?? throw new ArgumentNullException(nameof(emailValidator));
            _phoneValidator = phoneValidator ?? throw new ArgumentNullException(nameof(phoneValidator));
            _user = user ?? throw new ArgumentNullException(nameof(user));
            _password = password ?? throw new ArgumentNullException(nameof(password));
            _jwt = jwt ?? throw new ArgumentNullException(nameof(jwt));
        }
        public async Task<AutoWrap> LoginAdmin(LoginAdminDTO login)
        {
            var result = await GenerateJwtToken(login.Username, login.Password, ConnectionType.Admin);
            return new AutoWrap("Successfully Logged in!", true, 200);
        }

        public async Task<JwtElements> GenerateJwtToken(string username, string password, ConnectionType connectionType)
        {
            if (username.IsEmail())
            {
                username = _emailValidator.Validate(username, connectionType)
                                            .CheckIfEmailExists()
                                            .Build();
            }
            else if (username.IsPhone())
            {
                username = _phoneValidator.Validate(username, connectionType)
                                            .CheckIfPhoneNumberExists()
                                            .Build();
            }
            else
            {
                throw new ApiException("User does not exists!", 400);
            }

            var hashedPassword = await _user.GetUserHashedPasswordByUsername(username, connectionType);
            var validateHashedPassword = _password.PasswordChecker(hashedPassword, password);

            if (!validateHashedPassword)
            {
                throw new ApiException("Invalid password!", 400);
            }

            var userInfo = await _user.GetUserInfoByUsername(username, connectionType);

            var getJwt = await _jwt.GenerateJwtToken(new UserInfoViewModel
            {
                UserId = userInfo.UserId,
                Username = userInfo.Username,
                Firstname = userInfo.Firstname,
                Lastname = userInfo.Lastname
            }).ConfigureAwait(false);

            await _jwt.AddRefreshToken(userInfo.UserId, getJwt.RefreshToken, connectionType);

            return getJwt;
        }

    }
}
