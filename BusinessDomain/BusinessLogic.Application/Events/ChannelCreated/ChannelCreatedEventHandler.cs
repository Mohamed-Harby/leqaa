using System.Text;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Channels;
using BusinessLogic.Domain.Common.Events;
using Mapster;
using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace BusinessLogic.Application.Events.ChannelCreated;
public class ChannelCreatedEventHandler : INotificationHandler<ChannelCreatedEvent>
{
    private readonly IModel _rabbitMqChannel;

    public ChannelCreatedEventHandler(IRabbitMQConnector rabbitMqConnector, IConfiguration configuration)
    {

        _rabbitMqChannel = rabbitMqConnector.ConnectAsync(configuration).GetAwaiter().GetResult();
    }

    public Task Handle(ChannelCreatedEvent notification, CancellationToken cancellationToken)
    {
        _rabbitMqChannel.ExchangeDeclare(
            Constants.BusinessChannelExchange,
            ExchangeType.Fanout);

        _rabbitMqChannel.QueueDeclare(
            Constants.ChannelCreatedQueue,
            durable: true,
            exclusive: false,
            autoDelete: false,
            arguments: null);

        _rabbitMqChannel.QueueBind(Constants.ChannelCreatedQueue, Constants.BusinessChannelExchange, routingKey: string.Empty);

        var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(notification.channel.Adapt<ChannelReadModel>()));

        _rabbitMqChannel.BasicPublish(
            exchange: Constants.BusinessChannelExchange,
            routingKey: string.Empty,
            basicProperties: null,
            body: body);
        return Task.CompletedTask;
    }
}
