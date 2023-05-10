namespace Authentication.Infrastructure.NetworkCalls.MessageQueue;
public static class RabbitMQConstants
{
    public const string AuthenticationExchange = "Authentication";
    public const string UserToBusiness = "Authentication.UserToBusiness";
    public const string UserToChat = "Authentication.UserToChat";
}