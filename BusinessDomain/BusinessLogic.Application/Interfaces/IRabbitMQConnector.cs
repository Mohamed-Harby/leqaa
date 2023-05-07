using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;

namespace BusinessLogic.Application.Interfaces;
public interface IRabbitMQConnector
{
    Task<IModel> ConnectAsync(IConfiguration configuration);
}