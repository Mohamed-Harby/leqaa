using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Interfaces.TextChat;
using BusinessLogic.Application.Models.TextChatModels.ChatWithUser;
using BusinessLogic.Application.Models.TextChatModels.SendMessage;
using ErrorOr;

namespace BusinessLogic.Application.Commands.Users.SendMessage;
public class SendMessageCommandHandler : IHandler<SendMessageCommand, ErrorOr<SendMessageResponseModel>>
{
    private readonly ITextChatService _textChatService;
    private readonly IUserRepository _userRepository;

    public SendMessageCommandHandler(ITextChatService textChatService, IUserRepository userRepository)
    {
        _textChatService = textChatService;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<SendMessageResponseModel>> Handle(SendMessageCommand request, CancellationToken cancellationToken)
    {
        Guid userId = (await _userRepository.GetAsync(u => u.UserName == request.UserName)).FirstOrDefault()!.Id;
        var chatWithUserRequest = new ChatWithUserRequestModel(userId);
        try
        {
            var chatId = (await _textChatService.ChatWithUser(chatWithUserRequest))._id;
            var sendMessageRequest = new SendMessageRequestModel(request.Content, chatId);
            var result = await _textChatService.SendMessage(sendMessageRequest);
            return result;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return Error.Failure("User.CouldNotSendMessage", "Message could not be sent, please try again or use different format");
        }
    }
}
