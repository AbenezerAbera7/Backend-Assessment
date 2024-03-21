﻿using Application.Features.Task.DTOs;
using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Task.CQRS.Commands
{
    public class UpdateTaskCommand : IRequest<BaseCommandResponse<Unit>>
    {
        public UpdateTaskDto updateTaskDto { get; set; }

        public int UserId { get; set; }
    }
}
