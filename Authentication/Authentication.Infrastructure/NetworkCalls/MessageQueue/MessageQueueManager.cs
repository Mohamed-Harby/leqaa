using System.Text;
using Authentication.Application.Interfaces;
using Authentication.Application.Models;
using Authentication.Infrastructure.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace Authentication.Infrastructure.NetworkCalls.MessageQueue;
public class MessageQueueManager : IMessageQueueManager
{
    private readonly IModel channel;
    public MessageQueueManager(IOptions<RabbitMQConnectionModel> rabbitMQConnectionModelOptions)
    {
        RabbitMQConnectionModel rabbitMQConnectionModel = rabbitMQConnectionModelOptions.Value;
        var connectionFactory = new ConnectionFactory
        {
            HostName = rabbitMQConnectionModel.Host,
            Port = rabbitMQConnectionModel.Port,
            UserName = rabbitMQConnectionModel.Username,
            Password = rabbitMQConnectionModel.Password
        };
        System.Console.WriteLine(rabbitMQConnectionModel.Host);
        System.Console.WriteLine(rabbitMQConnectionModel.Username);
        channel = connectionFactory.CreateConnection().CreateModel();

    }
    public void PublishUser(UserReadModel userReadModel)
    {
        channel.ExchangeDeclare(
            exchange: RabbitMQConstants.AuthenticationExchange,
            type: ExchangeType.Fanout,
            durable: false,
            autoDelete: false
        );
        channel.QueueDeclare(
            queue: RabbitMQConstants.UserToBusiness,
            durable: false,
            exclusive: false,
            autoDelete: false
        );
        channel.QueueDeclare(
            queue: RabbitMQConstants.UserToChat,
            durable: false,
            exclusive: false,
            autoDelete: false
        );
        channel.QueueBind(
            queue: RabbitMQConstants.UserToBusiness,
            exchange: RabbitMQConstants.AuthenticationExchange,
            RabbitMQConstants.UserToBusiness);
        channel.QueueBind(
            queue: RabbitMQConstants.UserToChat,
            exchange: RabbitMQConstants.AuthenticationExchange,
            RabbitMQConstants.UserToChat);


        IBasicProperties props = channel.CreateBasicProperties();
        props.ContentType = "application/json";
        props.DeliveryMode = 2;

        string serializedUser = JsonConvert.SerializeObject(userReadModel);
        byte[] convertedUser = Encoding.UTF8.GetBytes(serializedUser);

        channel.BasicPublish(
            exchange: RabbitMQConstants.AuthenticationExchange,
            routingKey: "",
            mandatory: false,
            basicProperties: props,
            convertedUser);
    }
}