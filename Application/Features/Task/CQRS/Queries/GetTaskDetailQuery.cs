using Application.Features.Task.DTOs;
using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Task.CQRS.Queries
{
    public class GetTaskDetailQuery : IRequest<GetTaskDetailDto>
    {
        public int Id { get; set; }

        public int UserId { get; set; }
    }
}
