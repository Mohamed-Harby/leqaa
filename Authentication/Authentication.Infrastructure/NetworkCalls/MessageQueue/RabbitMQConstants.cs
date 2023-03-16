namespace Authentication.Infrastructure.NetworkCalls.MessageQueue;
public static class RabbitMQConstants
{
    public const string AuthenticationExchange = "Authentication";
    public const string UserQueue = "Authentication.User";
}