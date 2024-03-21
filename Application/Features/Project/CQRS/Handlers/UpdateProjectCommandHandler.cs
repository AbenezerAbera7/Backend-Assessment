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
    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;


        public UpdateProjectCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IUnitOfWork UnitOfWork => _unitOfWork;
        public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateProjectDtoValidation(UnitOfWork.ProjectRepository);
            var validationResult = await validator.ValidateAsync(request.updateProjectDto);


            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var Project = await UnitOfWork.ProjectRepository.Get(request.updateProjectDto.Id);

            if (Project.OwnerId != request.UserId)
                throw new UnauthorizedException("Project doesn't belong to you");

            _mapper.Map(request.updateProjectDto, Project);
            await UnitOfWork.ProjectRepository.Update(Project);

            if (await UnitOfWork.Save() < 0)
                throw new ActionNotPerfomedException("Project not Updated");

            return Unit.Value;
        }
    }
}
