using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Interfaces.TextChat;
using BusinessLogic.Application.Models.TextChatModels.SendMessage;
using ErrorOr;

namespace BusinessLogic.Application.Queries.Channels.FetchChannelMessages;
public class FetchChannelMessagesCommandHandler : IHandler<FetchChannelMessagesQuery, ErrorOr<List<SendMessageResponseModel>>>
{
    private readonly ITextChatService _textChatService;

    public FetchChannelMessagesCommandHandler(ITextChatService textChatService)
    {
        _textChatService = textChatService;
    }

    public async Task<ErrorOr<List<SendMessageResponseModel>>> Handle(FetchChannelMessagesQuery request, CancellationToken cancellationToken)
    {
        return await _textChatService.GetMessagesFromChat(request.ChannelId);
    }
}