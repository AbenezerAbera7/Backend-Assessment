using Application.Features.Project.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Project.CQRS.Commands
{
    public class CreateProjectCommand : IRequest<int>
    {
        public CreateProjectDto createProjectDto { get; set; }

        public int UserId { get; set; }
    }
}
