using BusinessLogic.Application.Commands.Hubs.AddHub;
using FluentValidation;

namespace BusinessLogic.Application.Validations;
public class HubValidator : AbstractValidator<AddHubCommand>
{
    public HubValidator()
    {
        RuleFor(h => h.Name)
        .NotEmpty()
        .MaximumLength(100)
        .WithMessage("Hub name is neither empty or too long, Please specify only 100 characters or less");

        RuleFor(h => h.Description)
        .MaximumLength(4000)
        .WithMessage("Hub description is too long, Please specify only 4000 characters or less");

    }
}