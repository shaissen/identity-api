using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Pendulum.Identity.Data.Interface.CommandInterface;
using Pendulum.Identity.Data.Interface.QueryInterface;
using Pendulum.Identity.Domain;
using Pendulum.Identity.Domain.Constants;
using Pendulum.Identity.Domain.Enums;
using Pendulum.Identity.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Pendulum.Identity.Service.Helpers
{
    public class JwtHelper : IJwtHelper
    {
        private readonly IOptions<JwtCredentials> _jwt;
        private readonly IRefreshTokenQuery _refreshTokenQuery;
        private readonly IRefreshTokenCommand _refreshTokenCommand;

        public JwtHelper(IOptions<JwtCredentials> jwt, IRefreshTokenQuery refreshTokenQuery, IRefreshTokenCommand refreshTokenCommand)
        {
            this._jwt = jwt ?? throw new ArgumentNullException(nameof(jwt));
            this._refreshTokenQuery = refreshTokenQuery ?? throw new ArgumentNullException(nameof(refreshTokenQuery));
            this._refreshTokenCommand = refreshTokenCommand ?? throw new ArgumentNullException(nameof(refreshTokenCommand));
        }

        public async Task AddRefreshToken(Guid? userId, string token, ConnectionType connectionType)
        {
            var refreshToken = await _refreshTokenQuery.GetRefreshTokenByUserId(userId, connectionType);

            if (refreshToken == null)
            {
                await _refreshTokenCommand.InsertRefreshToken(new RefreshTokenElements
                {
                    UserId = userId,
                    Token = token
                }, connectionType);
            }

            else
            {
                await _refreshTokenCommand.UpdateRefreshToken(new RefreshTokenElements
                {
                    UserId = userId,
                    Token = token
                }, connectionType);
            }
        }


        public Task<JwtElements> GenerateJwtToken(UserInfoViewModel userInfo)
        {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Value.Key));
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.Username),
                new Claim(JwtRegisteredClaimNames.UniqueName, $"{userInfo.Username} {userInfo.Lastname}"),
                new Claim(JwtRegisteredClaimNames.NameId, userInfo.UserId.ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, Guid.NewGuid().ToString())
            };

            var jwtTokens = new JwtSecurityToken(
                            issuer: _jwt.Value.Issuer,
                            audience: _jwt.Value.Audience,
                            claims: claims,
                            signingCredentials: credentials);


            var generateToken = new JwtSecurityTokenHandler().WriteToken(jwtTokens);

            JwtElements jwt = new JwtElements()
            {
                Token = generateToken,
                TokenType = "Bearer",
                RefreshToken = GenerateRefreshToken
            };

            var result = Task.FromResult<JwtElements>(jwt);

            return result;
        }


        private string GenerateRefreshToken
        {
            get
            {
                var randomNumber = new byte[32];
                using (var generate = RandomNumberGenerator.Create())
                {
                    generate.GetBytes(randomNumber);
                    return Convert.ToBase64String(randomNumber);
                }
            }
        }
    }
}
