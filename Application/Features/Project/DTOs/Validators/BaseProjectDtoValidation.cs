using Application.Features.Project.DTOs.Common;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Project.DTOs.Validators
{
    public class BaseProjectDtoValidation<T> : AbstractValidator<T> where T : BaseProjectDto
    {
        public BaseProjectDtoValidation()
        {
            RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Title cannot be empty.")
            .MaximumLength(50).WithMessage("Title cannot exceed 50 characters.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description cannot be empty.")
                .MaximumLength(200).WithMessage("Description cannot exceed 200 characters.");
        }
    }
}
