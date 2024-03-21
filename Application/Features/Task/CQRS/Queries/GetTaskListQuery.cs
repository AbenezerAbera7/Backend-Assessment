using Application.Features.Task.DTOs;
using Application.Responses;
using MediatR;

namespace Application.Features.Task.CQRS.Queries
{
    public class GetTaskListQuery : IRequest<List<GetTaskListDto>>
    {
        public int UserId { get; set; }
    }
}
