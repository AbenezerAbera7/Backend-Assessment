using Application.Contracts.Identity;
using Application.Features.Auth.CQRS.Commands;
using Application.Features.Auth.DTOs;
using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.CQRS.Handlers
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, BaseCommandResponse<LoginResponseDto>>
    {
        private readonly IAuthService _authService;

        public RegisterUserCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }
        public Task<BaseCommandResponse<LoginResponseDto>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            return _authService.Register(request.RegisterUserDto, cancellationToken);
        }
    }
}
