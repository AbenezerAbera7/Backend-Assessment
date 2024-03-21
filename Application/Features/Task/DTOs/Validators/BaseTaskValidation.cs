using Application.Features.Task.DTOs.Common;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Task.DTOs.Validators
{
    public class BaseTaskValidation<T> : AbstractValidator<T> where T : BaseTaskDto
    {

        public BaseTaskValidation()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title cannot be empty");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description cannot be empty");

        }

    }
}
