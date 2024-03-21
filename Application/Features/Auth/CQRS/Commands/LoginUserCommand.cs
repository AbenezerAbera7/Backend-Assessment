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
    public class LoginUserCommand : IRequest<BaseCommandResponse<LoginResponseDto>>
    {
        public LoginUserDto LoginUserDto { get; set; } = null!;
    }
}
