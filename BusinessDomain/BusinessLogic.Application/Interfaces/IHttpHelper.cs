namespace BusinessLogic.Application.Interfaces;
public interface IHttpHelper
{
    Task WriteBody(dynamic body, int statusCode);
}