using BusinessLogic.Application.Interfaces.TextChat;
using BusinessLogic.Application.Models.TextChatModels.AddUserToGroup;
using BusinessLogic.Domain.Common.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BusinessLogic.Application.Events.UserLeftChannel;
public class UserLeftChannelEventHandler : INotificationHandler<UserLeftChannelEvent>
{
    private readonly ITextChatService _textChatService;
    private readonly ILogger<UserLeftChannelEventHandler> _logger;

    public UserLeftChannelEventHandler(ITextChatService textChatService, ILogger<UserLeftChannelEventHandler> logger)
    {
        _textChatService = textChatService;
        _logger = logger;
    }

    public async Task Handle(UserLeftChannelEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"User {notification.UserId} left channel {notification.ChannelId}");

        var response = await _textChatService.RemoveUserFromGroup(new AddRemoveUserGroupRequestModel
        {
            chatId = notification.ChannelId,
            userId = notification.UserId
        });
        Console.WriteLine("chatName" + response.chatName);


    }
}
