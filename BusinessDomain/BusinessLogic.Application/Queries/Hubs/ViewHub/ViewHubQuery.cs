using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Models.Hubs;
using ErrorOr;

namespace BusinessLogic.Application.Queries.Hubs.ViewHub;
public record ViewHubQuery(
    Guid Id
) : IQuery<ErrorOr<HubReadModel>>;