namespace Authentication.Infrastructure.Models;
public class RabbitMQConnectionModel
{
    public string Host = string.Empty;
    public int Port { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}