using BusinessLogic.Infrastructure.Models;
using BusinessLogic.Infrastructure.NetworkCalls.MessageQueue;
using RabbitMQ.Client;

namespace BusinessLogic.Entry.ServiceConfigurations;
public static class RabbitMQConfiguration
{
    public static IModel ConnectToRabbitMQ(IConfiguration configuration)
    {
        RabbitMQConnection rabbit = new();
        configuration.GetSection("RabbitMQConnection").Bind(rabbit);
        var connectionFactory = new ConnectionFactory();
        connectionFactory.HostName = rabbit.Host;
        connectionFactory.Port = rabbit.Port;
        connectionFactory.UserName = rabbit.Username;
        connectionFactory.Password = rabbit.Password;
        IModel channel = connectionFactory.CreateConnection().CreateModel();
        return channel;
    }
}