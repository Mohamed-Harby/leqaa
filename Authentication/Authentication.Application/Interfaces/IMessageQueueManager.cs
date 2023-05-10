using Authentication.Application.Models;

namespace Authentication.Application.Interfaces;
public interface IMessageQueueManager
{
    void PublishUser(UserReadModel userReadModel);
}