using System.Text;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Channels;
using BusinessLogic.Domain;
using BusinessLogic.Infrastructure.Models;
using BusinessLogic.Persistence;
using BusinessLogic.Persistence.Repositories;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace BusinessLogic.Infrastructure.NetworkCalls.MessageQueue;
public class MessageQueueHelper
{
    public static Task SubscribeToRegisterUsersQueue(IModel channel, IConfiguration configuration)
    {


        channel.ExchangeDeclare(
             exchange: "Authentication",
             type: ExchangeType.Topic,
             durable: false,
             autoDelete: false
         );
        channel.QueueDeclare(
            queue: "Authentication.User",
            durable: false,
            exclusive: false,
            autoDelete: false
        );
        channel.QueueBind(
            queue: "Authentication.User",
            exchange: "Authentication",
            "Authentication.User");
        var consumer = new EventingBasicConsumer(channel);
        var options = new DbContextOptions<ApplicationDbContext>();
        consumer.Received += async (ch, ea) =>
         {
             var dbcontext = new ApplicationDbContext(options, configuration);
             IUserRepository userRepository = new UserRepository(dbcontext);
             var userEncoded = ea.Body.ToArray();
             var userDecoded = Encoding.UTF32.GetString(userEncoded);
             UserWriteModel userDeserialialized = JsonConvert.DeserializeObject<UserWriteModel>(userDecoded)!;
             await userRepository.AddAsync(userDeserialialized.Adapt<User>());
             await userRepository.SaveAsync();
             channel.BasicAck(ea.DeliveryTag, false);
         };
        var channelTag = channel.BasicConsume("Authentication.User", false, consumer);

        return Task.CompletedTask;
    }
}
