using Application.Contracts.Persistence;
using Application.Exceptions;
using Application.Features.Project.CQRS.Commands;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Project.CQRS.Handlers
{
    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;


        public DeleteProjectCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var Project = await _unitOfWork.ProjectRepository.Get(request.OwnerId);

            if (Project.OwnerId != request.OwnerId)
                throw new UnauthorizedException("Project doesn't belong to you");

            await _unitOfWork.ProjectRepository.Delete(Project);

            if (await _unitOfWork.Save() < 0)
                throw new ActionNotPerfomedException("Project not Deleted");

            return Unit.Value;
        }
    }
}
