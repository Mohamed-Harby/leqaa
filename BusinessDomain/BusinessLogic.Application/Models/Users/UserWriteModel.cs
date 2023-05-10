using BusinessLogic.Domain.Enums;

namespace BusinessLogic.Application.Models.Channels;
public record UserWriteModel(
    Guid Id,
    string Name,
    string Email,
    string UserName,
    Gender Gender
);