namespace Authentication.Application.Models;
public record LoginCredentials(
    string UserName,
    string Password
);