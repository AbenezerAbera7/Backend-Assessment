using Application.Contracts.Persistence;
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
    public class GetProjectListQueryHandler : IRequestHandler<GetProjectListQuery, List<GetProjectListDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public GetProjectListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<GetProjectListDto>> Handle(GetProjectListQuery request, CancellationToken cancellationToken)
        {
            var Projects = await _unitOfWork.ProjectRepository.GetAll();
            var ProjectDtos = _mapper.Map<List<GetProjectListDto>>(Projects);


            return ProjectDtos;
        }
    }
}
