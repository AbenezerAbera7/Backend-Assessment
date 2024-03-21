using Application.Features.Project.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Project.CQRS.Queries
{
    public class GetProjectDetailQuery : IRequest<GetProjectDetailDto>
    {
        public int ProjectId { get; set; }

        public int UserId { get; set; }

    }
}
