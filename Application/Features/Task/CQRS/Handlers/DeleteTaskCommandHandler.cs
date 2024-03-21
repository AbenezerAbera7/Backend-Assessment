using Application.Contracts.Persistence;
using Application.Exceptions;
using Application.Features.Task.CQRS.Commands;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Task.CQRS.Handlers
{
    public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;


        public DeleteTaskCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<Unit> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var Task = await _unitOfWork.TaskRepository.Get(request.TaskId);
            if (Task == null)
                throw new NotFoundException("Task", nameof(Task));

            if (Task.UserId != request.UserId)
                throw new UnauthorizedException($"ac = {Task.UserId} and {request.UserId}");

            await _unitOfWork.TaskRepository.Delete(Task);

            if (await _unitOfWork.Save() < 0)
                throw new ActionNotPerfomedException("Task not Deleted");

            return Unit.Value;
        }
}
