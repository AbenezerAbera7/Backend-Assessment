using Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Task.DTOs.Validators
{
    public class CreateTaskDtoValidation : BaseTaskValidation<CreateTaskDto>
    {
        private readonly IUserRepository _userRepository;

        public CreateTaskDtoValidation(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            RuleFor(x => x.UserId)
            .MustAsync(UserExists).WithMessage("User does not exist.");
        }

        private async Task<bool> UserExists(int UserId, CancellationToken cancellationToken)
        {
            return await _userRepository.Exists(UserId);
        }
    }
}
