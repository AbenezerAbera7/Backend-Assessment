using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Task.CQRS.Commands
{
    public class DeleteTaskCommand : IRequest<BaseCommandResponse<Unit>>
    {
        public int TaskId { get; set; }

        public int UserId { get; set; }
    }
}
