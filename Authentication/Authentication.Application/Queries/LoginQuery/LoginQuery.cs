

using Authentication.Application.CommandInterfaces;

namespace Authentication.Application.Queries.LoginQuery;
public record LoginQuery(
    string UserName,
    string Password
) : IQuery;