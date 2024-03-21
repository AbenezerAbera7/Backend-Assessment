using Application.Features.Auth.DTOs;
using Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Identity
{
    public interface IAuthService
    {
        Task<BaseCommandResponse<LoginResponseDto>> Login(LoginUserDto authRequest, CancellationToken cancellationToken = default);
        Task<BaseCommandResponse<LoginResponseDto>> Register(RegisterUserDto registrationRequest, CancellationToken cancellationToken = default);
    }
}
