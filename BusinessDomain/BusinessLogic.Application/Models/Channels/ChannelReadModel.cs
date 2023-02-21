
namespace BusinessLogic.Application.Models.Channels;
public record ChannelReadModel(
Guid Id,
string hubId,
string name,
string description,
string? logo
);
