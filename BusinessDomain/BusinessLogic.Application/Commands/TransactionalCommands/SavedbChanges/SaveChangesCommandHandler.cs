using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Interfaces;
using ErrorOr;
using MediatR;

namespace BusinessLogic.Application.Commands.TransactionalCommands;
public class SaveChangesCommandHandler : IHandler<SaveChangesCommand, ErrorOr<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public SaveChangesCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<int>> Handle(SaveChangesCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return await _unitOfWork.SaveAsync();
        }
        catch
        {
            return Error.Failure("Transactions.SaveChanges", "Failed to persist data");
        }
    }
}
