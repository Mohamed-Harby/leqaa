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
        System.Console.WriteLine(rabbit.Host);
        System.Console.WriteLine(rabbit.Port);
        System.Console.WriteLine(rabbit.UserName);
        System.Console.WriteLine(rabbit.Password);
        connectionFactory.HostName = rabbit.Host;
        connectionFactory.Port = rabbit.Port;
        connectionFactory.UserName = rabbit.UserName;
        connectionFactory.Password = rabbit.Password;
        IModel channel = connectionFactory.CreateConnection().CreateModel();
        return channel;
    }
}