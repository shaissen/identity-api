using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Pendulum.Identity.Domain.Constants;
using Pendulum.Identity.Service.Builder;
using Pendulum.Identity.Service.Helpers;
using Pendulum.Identity.Service.Interface;
using Pendulum.Identity.Service.Services.QueryService;
using System.Text;
using System.Transactions;

namespace Pendulum.Identity.Service.Dependency
{
    public static class ServiceDependency
    {
        public static void AddServiceDependency(this IServiceCollection service)
        {
            #region Query
            service.AddScoped<ILoginService, LoginService>();
            #endregion


            #region Command
            #endregion


            #region Helper
            service.AddScoped<IJwtHelper, JwtHelper>();
            service.AddScoped<IPasswordHelper, PasswordHelper>();
            #endregion


            #region Builder
            service.AddScoped<IEmailBuilder, EmailBuilder>();
            service.AddScoped<IPhoneBuilder, PhoneBuilder>();
            #endregion
        }

        public static void AddJwtSchemeAuthentication(this IServiceCollection service, Action<JwtCredentials> jwt)
        {
            var jwtCredentials = new JwtCredentials();
            jwt(jwtCredentials);

            service.AddAuthentication(jwt =>
            {
                var scheme = JwtBearerDefaults.AuthenticationScheme;

                jwt.DefaultAuthenticateScheme = scheme;
                jwt.DefaultChallengeScheme = scheme;
                jwt.DefaultScheme = scheme;

            }).AddJwtBearer(bearer =>
            {
                bearer.SaveToken = true;
                bearer.RequireHttpsMetadata = false;
                bearer.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtCredentials.Issuer,
                    ValidAudience = jwtCredentials.Audience,
                    RequireExpirationTime = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtCredentials.Key))
                };
            });
        }
    }
}

