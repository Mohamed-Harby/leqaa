namespace Authentication.Infrastructure.Models;
public class Jwt
{
    public string Issuer { get; init; } = string.Empty;
    public string Audience { get; init; } = string.Empty;
    public string Key { get; init; } = string.Empty;
    public int ExpiresAfterInHours { get; init; }
}