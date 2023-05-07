using BusinessLogic.Application.Interfaces;
using BusinessLogic.Infrastructure.NetworkCalls.MessageQueue.Models;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;

namespace BusinessLogic.Infrastructure.NetworkCalls.MessageQueue;
public class RabbitMQConnector: IRabbitMQConnector
{
    public Task<IModel> ConnectAsync(IConfiguration configuration)
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
        return Task.FromResult<IModel>(channel);
    }
}