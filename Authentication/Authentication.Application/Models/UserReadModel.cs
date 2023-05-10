using Authentication.Domain.Entities.ApplicationUser.Enums;

namespace Authentication.Application.Models;
public record UserReadModel(
    Guid Id,
    string Name,
    string Email,
    string UserName,
    Gender Gender
    );