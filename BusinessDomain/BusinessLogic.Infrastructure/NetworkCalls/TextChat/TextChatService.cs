using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Interfaces.TextChat;
using BusinessLogic.Application.Models;
using BusinessLogic.Application.Models.TextChatModels.AddUserToGroup;
using BusinessLogic.Application.Models.TextChatModels.Chat;
using BusinessLogic.Application.Models.TextChatModels.ChatWithUser;
using BusinessLogic.Application.Models.TextChatModels.CreateGroup;
using BusinessLogic.Application.Models.TextChatModels.SendMessage;
using BusinessLogic.Application.Models.TextChatModels.User;
using BusinessLogic.Infrastructure.NetworkCalls.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using SocketIOClient;

namespace BusinessLogic.Infrastructure.NetworkCalls.TextChat;
public class TextChatService : ITextChatService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IHttpContextAccessor _httpAccessor;
    private readonly HttpHelper _httpHelper;
    private readonly IAPIHelper _apiHelper;
    private readonly SocketIO socket;

    public TextChatService(
        IHttpClientFactory httpClientFactory,
        IHttpContextAccessor httpAccessor,
        HttpHelper httpHelper,
        IConfiguration configuration,
        IAPIHelper apiHelper)
    {
        _httpClientFactory = httpClientFactory;
        _httpAccessor = httpAccessor;
        _httpHelper = httpHelper;
        socket = new SocketIO(configuration.GetSection("textChatUri").Value, new SocketIOOptions
        {
            Reconnection = false
        });
        socket.ConnectAsync();
        socket.OnConnected += (_, eventArgs) =>
        {
            Console.WriteLine("connected to a server socket");
        };
        _apiHelper = apiHelper;
    }

    public async Task<UserResponseModel> SearchUser(string username)
    {
        var requestModel = new APIRequestModel
        {
            APIName = ServiceNames.TextChatAPI,
            HttpMethod = HttpMethod.Get,
            Url = $"api/user?search={username}",
        };
        var response = await _apiHelper.SendAsync<List<UserResponseModel>>(requestModel);
        return response[0];
    }

    public async Task<ChatWithUserResponseModel> ChatWithUser(ChatWithUserRequestModel chatWithUserRequestModel)
    {
        var requestModel = new APIRequestModel
        {
            APIName = ServiceNames.TextChatAPI,
            HttpMethod = HttpMethod.Post,
            Url = "api/chat",
            RequestContent = chatWithUserRequestModel
        };
        return await _apiHelper.SendAsync<ChatWithUserResponseModel>(requestModel);
    }
    public async Task<SendMessageResponseModel> SendMessage(SendMessageRequestModel sendMessageRequestModel)
    {
        socket.On("message recieved", data => Console.WriteLine(data));
        var requestModel = new APIRequestModel
        {
            APIName = ServiceNames.TextChatAPI,
            HttpMethod = HttpMethod.Post,
            Url = "api/message",
            RequestContent = sendMessageRequestModel
        };
        var response = await _apiHelper.SendAsync<SendMessageResponseModel>(requestModel);
        await socket.EmitAsync("new message", response);
        return response;

        // worked when inputed a user found in mongodb 

    }
    public async Task<List<ChatResponseModel>> GetChats()
    {
        var requestModel = new APIRequestModel
        {
            APIName = ServiceNames.TextChatAPI,
            HttpMethod = HttpMethod.Get,
            Url = "api/chat",
        };
        return await _apiHelper.SendAsync<List<ChatResponseModel>>(requestModel);
    }
    public async Task<ChatResponseModel> CreateGroup(CreateGroupRequestModel createGroupRequestModel)
    {
        var requestModel = new APIRequestModel
        {
            APIName = ServiceNames.TextChatAPI,
            HttpMethod = HttpMethod.Post,
            Url = "api/chat/group",
            RequestContent = createGroupRequestModel
        };
        var response = await _apiHelper.SendAsync<ChatResponseModel>(requestModel);
        return response;
    }
    public async Task<ChatResponseModel> AddUserToGroup(AddRemoveUserGroupRequestModel addUserToGroupRequestModel)
    {
        var requestModel = new APIRequestModel
        {
            APIName = ServiceNames.TextChatAPI,
            HttpMethod = HttpMethod.Put,
            Url = "api/chat/groupadd",
            RequestContent = addUserToGroupRequestModel
        };
        var response = await _apiHelper.SendAsync<ChatResponseModel>(requestModel);
        return response;
    }
    public async Task<ChatResponseModel> RemoveUserFromGroup(AddRemoveUserGroupRequestModel removeUserFromGroupRequestModel)
    {
        var requestModel = new APIRequestModel
        {
            APIName = ServiceNames.TextChatAPI,
            HttpMethod = HttpMethod.Put,
            Url = "api/chat/groupremove",
            RequestContent = removeUserFromGroupRequestModel
        };
        var response = await _apiHelper.SendAsync<ChatResponseModel>(requestModel);
        return response;
    }
    public async Task<SendMessageResponseModel> GetMessagesFromChat(Guid chatId)
    {
        var requestModel = new APIRequestModel
        {
            APIName = ServiceNames.TextChatAPI,
            HttpMethod = HttpMethod.Get,
            Url = $"api/message/{chatId}"
        };
        var response = await _apiHelper.SendAsync<SendMessageResponseModel>(requestModel);
        return response;
    }
}