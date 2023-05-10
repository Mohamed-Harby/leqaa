using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Models.TextChatModels.SendMessage;
using ErrorOr;

namespace BusinessLogic.Application.Queries.Channels.FetchChannelMessages;

public record FetchChannelMessagesQuery(Guid ChannelId) : IQuery<ErrorOr<List<SendMessageResponseModel>>>;