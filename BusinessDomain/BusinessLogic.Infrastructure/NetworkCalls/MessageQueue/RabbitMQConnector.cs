using RabbitMQ.Client;

namespace BusinessLogic.Infrastructure.NetworkCalls.MessageQueue;
public static class RabbitMQConnector
{
    public static IModel ConnectAsync(string hostname, int port, string username, string password)
    {
        var connectionFactory = new ConnectionFactory();
        connectionFactory.HostName = hostname;
        connectionFactory.Port = port;
        connectionFactory.UserName = username;
        connectionFactory.Password = password;
        IConnection connection = connectionFactory.CreateConnection();
        return connection.CreateModel();
    }
}