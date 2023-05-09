using BusinessLogic.Application.Models;

namespace BusinessLogic.Application.Interfaces;
public interface IAPIHelper
{
    Task<TRes> SendAsync<TRes>(APIRequestModel requestModel);
}