using Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Task.DTOs.Validators
{
    public class UpdateTaskDtoValidation : BaseTaskValidation<UpdateTaskDto>
    {
        private readonly ITaskRepository _TaskRepository;

        public UpdateTaskDtoValidation(ITaskRepository TaskRepository)
        {
            _TaskRepository = TaskRepository;
            RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id cannot be empty.")
            .MustAsync(TaskExists).WithMessage("User task does not exist.");
        }
        private async Task<bool> TaskExists(int id, CancellationToken cancellationToken)
        {
            return await _TaskRepository.Exists(id);
        }
    }
}
