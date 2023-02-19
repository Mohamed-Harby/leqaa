using Authentication.Domain.Entities.ApplicationUser;

namespace Authentication.Application.Interfaces;
public interface IMessageQueueManager
{
    void PublishUser(ApplicationUser obj);
}