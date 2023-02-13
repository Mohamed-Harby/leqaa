

using Authentication.Application.CommandInterfaces;

namespace Authentication.Application.Queries.Login;
public record LoginQuery(
    string UserName,
    string Password
) : IQuery;