using System.Text;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Infrastructure.Models;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace BusinessLogic.Infrastructure.NetworkCalls.MessageQueue;
public class MessageQueueHelper : IMessageQueueHelper
{
    private readonly IModel channel;
    private readonly RabbitMQConnection connection;

    public MessageQueueHelper(IOptions<RabbitMQConnection> rabbitMQConnectionOptions)
    {
        connection = rabbitMQConnectionOptions.Value;
        this.channel = RabbitMQConnector.ConnectAsync(
            connection.Host,
            connection.Port,
            connection.Username,
            connection.Password);
    }
    public void SendTestMessage()
    {
        channel.ExchangeDeclare(
            "testExchange",
            type: ExchangeType.Direct,
            durable: false,
            autoDelete: false);

        channel.QueueDeclare(
            "testQueue3",
            durable: false,
            exclusive: false,
            autoDelete: false);

        channel.QueueBind("testQueue2", "testExchange", "testRoutingKey");

        var message = Encoding.UTF8.GetBytes("Hello World!");
        channel.BasicPublish("testExchange", "testRoutingKey", false, null, message);
        channel.Close();
    }
}
