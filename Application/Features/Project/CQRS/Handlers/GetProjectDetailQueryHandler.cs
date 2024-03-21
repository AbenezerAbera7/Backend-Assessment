using Application.Contracts.Persistence;
using Application.Exceptions;
using Application.Features.Project.CQRS.Queries;
using Application.Features.Project.DTOs;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Project.CQRS.Handlers
{
    public class GetProjectDetailQueryHandler : IRequestHandler<GetProjectDetailQuery, GetProjectDetailDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetProjectDetailQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<GetProjectDetailDto> Handle(GetProjectDetailQuery request, CancellationToken cancellationToken)
        {
            var Exists = await _unitOfWork.ProjectRepository.Exists(request.ProjectId);
            if (Exists == false)
                throw new NotFoundException(nameof(Domain.Entites.Project), request.ProjectId);

            var Project = await _unitOfWork.ProjectRepository.GetWithDetails(request.ProjectId);

            var ProjectDto = _mapper.Map<GetProjectDetailDto>(Project);
            return ProjectDto;
        }
    }
}
