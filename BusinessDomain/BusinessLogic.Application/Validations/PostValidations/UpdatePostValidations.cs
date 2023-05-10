﻿using BusinessLogic.Application.Models.Posts;
using BusinessLogic.Application.Commands.Posts.UpdatePost;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Application.Validations.PostValidations
{
    public class UpdatePostValidations: AbstractValidator<UpdatePostCommand>
    {
        public UpdatePostValidations() {


            RuleFor(h => h.Title)
          .NotEmpty()
          .MaximumLength(100)
          .WithMessage("Post Title is neither empty or too long, Please specify only 100 characters or less");

            RuleFor(h => h.Content)
            .MaximumLength(4000)
            .WithMessage("Channel content is too long, Please specify only 4000 characters or less");

        }
    }
}
