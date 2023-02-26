using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Models.Hubs;
using MediatR;

namespace BusinessLogic.Application.Queries.Hubs.GetAllHubs;
public record GetAllHubsQuery(

     int Limit,
 string Cursor

    ) : IQuery<List<HubReadModel>>;