using Application.Contracts.Persistence;
using Application.Features.Task.CQRS.Queries;
using Application.Features.Task.DTOs;
using Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Task.CQRS.Handlers
{
    public class GetTaskListQueryHandler : IRequestHandler<GetTaskListQuery, BaseCommandResponse<List<GetTaskListDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetTaskListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse<List<GetTaskListDto>>> Handle(GetTaskListQuery request, CancellationToken cancellationToken)
        {
            
        }
    }
}
