using BusinessLogic.Application.Models.Hubs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Application.Validations.HubValidations
{
 public class UpdateHubValidations: AbstractValidator<HubUpdateModel>
    {
        public UpdateHubValidations() {

            RuleFor(h => h.name)
          .NotEmpty()
          .MaximumLength(100)
          .WithMessage("Hub name is neither empty or too long, Please specify only 100 characters or less");

            RuleFor(h => h.description)
            .MaximumLength(4000)
            .WithMessage("Hub description is too long, Please specify only 4000 characters or less");
        }
    }
}
