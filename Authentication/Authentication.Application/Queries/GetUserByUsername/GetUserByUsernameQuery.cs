using Authentication.Application.CommandInterfaces;

namespace Authentication.Application.Queries.GetUserByUsername;
public record GetUserByUsername(
    string UserName
) : IQuery;