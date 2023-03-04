using BusinessLogic.Application.Commands.Channels.CreateChannel;
using FluentValidation;

namespace BusinessLogic.Application.Validations.ChannelValidations;
public class CreatePostValidations : AbstractValidator<CreateChannelCommand>
{
    public CreatePostValidations()
    {
        RuleFor(h => h.Name)
       .NotEmpty()
       .MaximumLength(100)
       .WithMessage("Channel name is neither empty or too long, Please specify only 100 characters or less");

        RuleFor(h => h.Description)
        .MaximumLength(4000)
        .WithMessage("Channel description is too long, Please specify only 4000 characters or less");
    }
}