using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AuthenticationOptions;
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


    public record Jwt
    {
        public string Issuer { get; init; } = string.Empty;
        public string Audience { get; init; } = string.Empty;
        public string Key { get; init; } = string.Empty;
        public int Expiry { get; init; }
    }
}