using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Authentication.Application.Interfaces;
using Authentication.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Authentication.Infrastructure;
public class JwtTokenGenerator : ITokenGenerator
{
    private readonly Jwt jwt;
    public JwtTokenGenerator(IOptions<Jwt> jwtOptions)
    {
        jwt = jwtOptions.Value;
    }
    public string Generate(IdentityUser user)
    {
        Claim[] claims = new Claim[]{
            new (ClaimTypes.NameIdentifier,user.UserName),
            new (ClaimTypes.Email,user.Email),
        };

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Base64UrlEncoder.DecodeBytes(jwt.Key)
            ),
            SecurityAlgorithms.HmacSha256);

        var jwtSecurityToken = new JwtSecurityToken(
            issuer: jwt.Issuer,
            audience: jwt.Audience,
            claims: claims,
            notBefore: null,
            expires: DateTime.Now.AddHours(jwt.Expiry),
            signingCredentials: signingCredentials
        );

        var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        return token;
    }
}
