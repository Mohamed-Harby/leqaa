using System.Text;
using Authentication.Infrastructure.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Authentication.Entry.Options;
public class JwtBearerOptionsSetup : IConfigureOptions<JwtBearerOptions>
{
    private readonly Jwt jwt;
    public JwtBearerOptionsSetup(IOptions<Jwt> jwtOptions)
    {
        jwt = jwtOptions.Value;
    }

    public void Configure(JwtBearerOptions options)
    { 
        options.TokenValidationParameters = new()
        {
            ValidIssuer = jwt.Issuer,
            ValidAudience = jwt.Audience,
            ValidateIssuer = true,
            ValidateAudience = true,
            IssuerSigningKey = new SymmetricSecurityKey(Base64UrlEncoder.DecodeBytes(jwt.Key)),
            ValidateIssuerSigningKey = true,
        };
    }
}