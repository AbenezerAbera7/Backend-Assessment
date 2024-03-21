using Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Project.DTOs.Validators
{
    public class UpdateProjectDtoValidation : BaseProjectDtoValidation<UpdateProjectDto>
    {
        private IProjectRepository _ProjectRepository;
        public UpdateProjectDtoValidation(IProjectRepository ProjectRepository)
        {
            _ProjectRepository = ProjectRepository;

            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id cannot be empty.")
                .MustAsync(ProjectExists).WithMessage("User task does not exist.");
        }
        private async Task<bool> ProjectExists(int id, CancellationToken cancellationToken)
        {
            return await _ProjectRepository.Exists(id);
        }
    }
}
