﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Project.CQRS.Commands
{
    public class DeleteProjectCommand : IRequest<Unit>
    {
        public int ProjectId { get; set; }

        public int OwnerId { get; set; }
    }
}
