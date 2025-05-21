using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CleanArch.Application.Services;
using CleanArch.Domain.Users;
using CleanArch.Infrastructure.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CleanArch.Infrastructure.Service;

internal sealed class JwtProvider(IOptions<JwtOptions> jwtOptions) : IJwtProvider
{
    public Task<string> CreateTokenAsync(AppUser user, string password, CancellationToken cancellationToken = default)
    {
        List<Claim> claims = new()
        {
            new Claim("user-id",user.Id.ToString())
        };


        var expires = DateTime.Now.AddDays(1);

        SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(jwtOptions.Value.SecretKey));
        SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha512);

        JwtSecurityToken JwtSecurityToken = new(
            issuer: jwtOptions.Value.Issuer,
            audience: jwtOptions.Value.Audience,
            claims: claims,
            notBefore: DateTime.Now,
            expires: expires,
            signingCredentials: signingCredentials
            );

        JwtSecurityTokenHandler handler = new();

        string token = handler.WriteToken(JwtSecurityToken);

        return Task.FromResult(token);
    }
}
