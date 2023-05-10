using BusinessLogic.Application.Commands.Rooms.AddRoom;
using FluentValidation;

namespace BusinessLogic.Application.Validations;
public class RoomValildations : AbstractValidator<CreateRoomCommand>
{
    public RoomValildations()
    {

    }
}