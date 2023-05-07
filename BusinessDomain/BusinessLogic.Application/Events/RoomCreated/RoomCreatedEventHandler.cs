using System.Text;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Domain.Common.Events;
using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace BusinessLogic.Application.Events.RoomCreated;
public class RoomCreatedEventHandler : INotificationHandler<RoomCreatedEvent>
{
    private readonly IModel _rabbitMqChannel;

    public RoomCreatedEventHandler( IRabbitMQConnector rabbitMqConnector, IConfiguration configuration)
    {

        _rabbitMqChannel = rabbitMqConnector.ConnectAsync(configuration).GetAwaiter().GetResult();
    }
    public Task Handle(RoomCreatedEvent notification, CancellationToken cancellationToken)
    {
        _rabbitMqChannel.ExchangeDeclare(
           Constants.BusinessRoomExchange,
           ExchangeType.Fanout);

        _rabbitMqChannel.QueueDeclare(
            Constants.RoomCreatedQueue,
            durable: true,
            exclusive: false,
            autoDelete: false,
            arguments: null);

        _rabbitMqChannel.QueueBind(Constants.RoomCreatedQueue, Constants.BusinessRoomExchange, routingKey: string.Empty);

        var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(notification));

        _rabbitMqChannel.BasicPublish(
            exchange: Constants.BusinessRoomExchange,
            routingKey: string.Empty,
            basicProperties: null,
            body: body);
        return Task.CompletedTask;
    }
}
