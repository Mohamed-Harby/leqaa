namespace Authentication.Application.Models;
public class AuthenticationResults
{
    public AuthenticationResults()
    {
        ErrorMessages = new List<string>();
    }
    public bool IsSuccess { get; set; }
    public string Token { get; private set; } = string.Empty;
    public List<string> ErrorMessages { get; private set; }
    public void AddErrorMessages(string errorMessage)
    {
        ErrorMessages.Add(errorMessage);
    }
    public void AddErrorMessages(string[] errorMessages)
    {
        ErrorMessages.AddRange(errorMessages);
    }
    public void SetToken(string token)
    {
        if (string.IsNullOrEmpty(Token))
            Token = token;
    }


}