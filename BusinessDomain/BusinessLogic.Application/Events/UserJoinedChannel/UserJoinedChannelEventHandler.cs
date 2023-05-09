using BusinessLogic.Application.Interfaces.TextChat;
using BusinessLogic.Application.Models.TextChatModels.AddUserToGroup;
using BusinessLogic.Domain.Common.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BusinessLogic.Application.Events.UserJoinedChannel;
public class UserJoinedChannelEventHandler : INotificationHandler<UserJoinedChannelEvent>
{
    private readonly ITextChatService _textChatService;
    private readonly ILogger<UserJoinedChannelEventHandler> _logger;

    public UserJoinedChannelEventHandler(ITextChatService textChatService, ILogger<UserJoinedChannelEventHandler> logger)
    {
        _textChatService = textChatService;
        _logger = logger;
    }

    public async Task Handle(UserJoinedChannelEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"User {notification.UserId} joined channel {notification.ChannelId}");
        var response = await _textChatService.AddUserToGroup(new AddRemoveUserGroupRequestModel
        {
            chatId = notification.ChannelId,
            userId = notification.UserId
        });
        Console.WriteLine("chatName" + response.chatName);
    }
}
