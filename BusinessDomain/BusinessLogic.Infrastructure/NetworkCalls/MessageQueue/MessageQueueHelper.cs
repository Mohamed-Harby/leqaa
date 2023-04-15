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
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogic.Infrastructure.NetworkCalls.MessageQueue;
public class MessageQueueHelper
{
    public static Task SubscribeToRegisterUsersQueue(IModel channel, IServiceProvider serviceProvider)
    {


        channel.ExchangeDeclare(
             exchange: "Authentication",
             type: ExchangeType.Fanout,
             durable: false,
             autoDelete: false
         );
        channel.QueueDeclare(
            queue: "Authentication.UserToBusiness",
            durable: false,
            exclusive: false,
            autoDelete: false
        );
        channel.QueueBind(
            queue: "Authentication.UserToBusiness",
            exchange: "Authentication",
            "Authentication.UserToBusiness");
        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += async (ch, ea) =>
         {

             var options = new DbContextOptions<ApplicationDbContext>();
             var dbcontext = new ApplicationDbContext(options, serviceProvider.GetRequiredService<IConfiguration>());
             IUserRepository userRepository = new UserRepository(dbcontext);
             var userEncoded = ea.Body.ToArray();
             var userDecoded = Encoding.UTF32.GetString(userEncoded);
             UserWriteModel userDeserialialized = JsonConvert.DeserializeObject<UserWriteModel>(userDecoded)!;
             await userRepository.AddAsync(userDeserialialized.Adapt<User>());
             await userRepository.SaveAsync();
             channel.BasicAck(ea.DeliveryTag, false);
         };
        var channelTag = channel.BasicConsume("Authentication.UserToBusiness", false, consumer);

        return Task.CompletedTask;
    }
}
