
using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Commands.Users.JoinHub;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Hubs;
using ErrorOr;
using BusinessLogic.Domain.Common.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;
using System.Diagnostics.Metrics;
using System.Reflection;
using BusinessLogic.Domain.SharedEnums;
using BusinessLogic.Domain;
using BusinessLogic.Domain.DomainSucceeded.User;
using MediatR;

namespace BusinessLogic.Application.Commands.Users.LeaveHub
{

    public class LeaveHubCommandHandler : IHandler<LeaveHubCommand, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly IHubRepository _hubRepository;
        private readonly IUserHubRepository _userHubRepository;

        public LeaveHubCommandHandler(
            IUserRepository userRepository,
            IHubRepository hubRepository,
            IUserHubRepository userHubRepository)
        {
            _userRepository = userRepository;
            _hubRepository = hubRepository;
            _userHubRepository = userHubRepository;
        }



        public async Task<string> Handle(LeaveHubCommand request, CancellationToken cancellationToken)
        {
            {
                var user = (await _userRepository.GetAsync(u => u.UserName == request.UserName)).FirstOrDefault()!;
                var hub = await _hubRepository.GetByIdAsync(request.HubId);

                if (hub is null)
                {
                    return "hub not found";
                }
                var userHub = (await _userHubRepository.GetAsync(uh => uh.UserId == user.Id && uh.HubId == hub.Id)).FirstOrDefault()!;
                if (userHub is null)
                {
                    return "user did't join to this hub";
                }
                if (userHub.Role == GroupRole.Founder)
                {
                    var newFounder = hub.JoinedUsers.FirstOrDefault(u => u.Id != user.Id);
                    if (newFounder is null)
                    {
                        // Delete the Hub if the leaving user is the last user in the Hub
                        _hubRepository.Remove(hub);
                        if (await _hubRepository.SaveAsync(cancellationToken) == 0)
                        {
                            return "can not leave leave hub";
                        }
                        return "user left and hub deleted";
                    }
                }
                hub.JoinedUsers.Remove(user);
                if (await _hubRepository.SaveAsync(cancellationToken) == 0)
                {
                    return "can't leave hub";
                }

                return "lefted successfully";
            }
        }
    }
}
