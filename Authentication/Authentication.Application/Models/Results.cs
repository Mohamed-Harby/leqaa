using Authentication.Domain.Entities.ApplicationUser;

namespace Authentication.Application.Models;
public class Results
{
    public Results()
    {
        ErrorMessages = new List<string>();
    }
    public bool IsSuccess { get; set; }
 
    public string Token { get; private set; } = string.Empty;
    public List<string> ErrorMessages { get; private set; }
    public UserReadModel? User { get; set; }
    public void AddErrorMessages(params string[] errorMessage)
    {
        ErrorMessages.AddRange(errorMessage);
    }
    public void SetToken(string token)
    {
        if (string.IsNullOrEmpty(Token))
            Token = token;
    }


}