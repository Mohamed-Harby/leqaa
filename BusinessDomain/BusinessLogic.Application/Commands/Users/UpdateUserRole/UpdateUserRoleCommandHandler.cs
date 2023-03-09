using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Commands.Hubs.DeleteHub;
using BusinessLogic.Application.Commands.Users.AddUserByUser;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Users;
using BusinessLogic.Domain;
using BusinessLogic.Domain.DomainErrors;
using BusinessLogic.Domain.DomainSucceeded.User;
using BusinessLogic.Domain.SharedEnums;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Application.Commands.Users.UpdateUserRole
{
    public class UpdateUserRoleCommandHandler : IHandler<UpdateUserRoleCommand, ErrorOr<Unit>>
    {

        private readonly IUserHubRepository _userHubRepository;
        private readonly IUserRepository _userRepository;

        public UpdateUserRoleCommandHandler(IPlanRepository planRepository,
            IUserRepository userRepository,

            IUserHubRepository userHubRepository,

            IChannelRepository channelRepository)
        {
            _userRepository = userRepository;

            _userHubRepository = userHubRepository;

        }
        public async Task<ErrorOr<Unit>> Handle(UpdateUserRoleCommand request, CancellationToken cancellationToken)
        {

            User? currentUser = (await _userRepository.GetAsync(u => u.UserName == request.userNameAdding)).FirstOrDefault()!;

            
            UserHub userHup = (await _userHubRepository.GetAsync(u => u.UserId == currentUser.Id)).FirstOrDefault()!;
            if (userHup.Role != GroupRole.Admin && userHup.Role != GroupRole.Founder)
            {
                return DomainErrors.User.UserDontHavePermession;
            }

            User? userToUpdateRole = (await _userRepository.GetAsync(u => u.UserName == request.userNameToUpdate)).FirstOrDefault()!;

            UserHub? userToUpdate = (await _userHubRepository.GetAsync(u => u.UserId == userToUpdateRole.Id)).FirstOrDefault();

          
         
            if (userToUpdate == null)
            {
                return DomainErrors.User.NotFound;
            }

    
            userToUpdate.Role = request.NewRole;
            var result = await _userHubRepository.UpdateAsync(userToUpdate);

            if(await _userHubRepository.SaveAsync() == 0)
            {
                return DomainErrors.UserHub.CouldNotProceed; 

            }
            return DomainSucceded.User.RoleAdded;

        }

    }
}
