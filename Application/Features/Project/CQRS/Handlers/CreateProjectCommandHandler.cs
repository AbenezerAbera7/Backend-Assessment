using Application.Contracts.Persistence;
using Application.Exceptions;
using Application.Features.Project.CQRS.Commands;
using Application.Features.Project.DTOs.Validators;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Project.CQRS.Handlers
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public CreateProjectCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateProjectDtoValidation(_unitOfWork.TaskRepository);
            var validationResult = await validator.ValidateAsync(request.createProjectDto);


            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var Project = _mapper.Map<Domain.Entites.Project>(request.createProjectDto);

            Project = await _unitOfWork.ProjectRepository.Add(Project);
            if (await _unitOfWork.Save() < 0)
                throw new ActionNotPerfomedException("Project not created");

            return Project.Id;
        }
    }
}
