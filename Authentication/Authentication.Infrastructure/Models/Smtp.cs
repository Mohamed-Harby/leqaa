namespace Authentication.Infrastructure.Models;
public record Smtp
{
    public string Host { get; set; } = string.Empty;
    public int Port;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}