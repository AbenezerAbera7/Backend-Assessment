using Application.Features.Auth.DTOs;
using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.CQRS.Commands
{
    public class RegisterUserCommand : IRequest<BaseCommandResponse<LoginResponseDto>>
    {
        public RegisterUserDto RegisterUserDto { get; set; } = null!;
    }
}
