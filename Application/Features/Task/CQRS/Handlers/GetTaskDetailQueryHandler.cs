using Application.Contracts.Persistence;
using Application.Exceptions;
using Application.Features.Task.CQRS.Queries;
using Application.Features.Task.DTOs;
using Application.Responses;
using AutoMapper;
using MediatR;

namespace Application.Features.Task.CQRS.Handlers
{
    public class GetTaskDetailQueryHandler : IRequestHandler<GetTaskDetailQuery, BaseCommandResponse<GetTaskDetailDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetTaskDetailQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) 
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse<GetTaskDetailDto>> Handle(GetTaskDetailQuery request, CancellationToken cancellationToken)
        {
            
        }
    }
}
