using Authentication.Domain.Entities.ApplicationUser.Enums;

namespace Authentication.Application.Models;
public record UserWriteModel(
    string Name,
    string Email,
    string Password,
    string UserName,
    Gender Gender
    );