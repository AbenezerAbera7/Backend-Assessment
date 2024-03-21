using Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Project.DTOs.Validators
{
    public class CreateProjectDtoValidation : BaseProjectDtoValidation<CreateProjectDto>
    {
        private readonly ITaskRepository _TaskRepository;
        public CreateProjectDtoValidation(ITaskRepository TaskRepository)
        {
            _TaskRepository = TaskRepository;
        }
        private async Task<bool> TaskExists(int userId, CancellationToken cancellationToken)
        {
            return await _TaskRepository.Exists(userId);
        }
    }
}
