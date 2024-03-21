using Application.Contracts.Identity;
using Application.Features.Auth.DTOs;
using Application.Responses;
using Domain.Entites;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IJwtFactory _jwtFactory;

        public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IJwtFactory jwtFactory)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtFactory = jwtFactory;
        }
        public async Task<BaseCommandResponse<LoginResponseDto>> Login(LoginUserDto authRequest, CancellationToken cancellationToken = default)
        {
            var userByEmail = await _userManager.FindByEmailAsync(authRequest.UserNameOrEmail);
            var userByUserName = await _userManager.FindByNameAsync(authRequest.UserNameOrEmail);

            if (userByEmail == null && userByUserName == null)
                return new BaseCommandResponse<LoginResponseDto>
                {
                    Success = false,
                    Message = "Invalid email or password."
                };

            var user = userByEmail ?? userByUserName;
            var result = await _signInManager.PasswordSignInAsync(user.UserName, authRequest.Password, false,
                false);

            if (!result.Succeeded)
                return new BaseCommandResponse<LoginResponseDto>
                {
                    Success = false,
                    Message = "Invalid email or password."
                };

            var jwtSecurityToken = await _jwtFactory.GenerateToken(user);

            return new BaseCommandResponse<LoginResponseDto>
            {
                Value = new LoginResponseDto
                {
                    User = UserDto.FromUser(user),
                    Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken)
                }
            };
        }

        public async Task<BaseCommandResponse<LoginResponseDto>> Register(RegisterUserDto registrationRequest, CancellationToken cancellationToken = default)
        {
            var existingUser = await _userManager.FindByNameAsync(registrationRequest.UserName) ??
                           await _userManager.FindByEmailAsync(registrationRequest.Email);

            if (existingUser != null)
                return new BaseCommandResponse<LoginResponseDto>
                {
                    Success = false,
                    Message = "User with the same email or username already exists."
                };

            var user = new AppUser
            {
                Email = registrationRequest.Email,
                UserName = registrationRequest.UserName,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, registrationRequest.Password);
            if (!result.Succeeded)
                return new BaseCommandResponse<LoginResponseDto>
                {
                    Success = false,
                    Errors = result.Errors.Select(x => x.Description).ToList()
                };

            await _userManager.AddToRoleAsync(user, "User");
            await _userManager.UpdateAsync(user);

            var jwtSecurityToken = await _jwtFactory.GenerateToken(user);

            return new BaseCommandResponse<LoginResponseDto>
            {
                Value = new LoginResponseDto()
                {
                    User = UserDto.FromUser(user),
                    Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken)
                }
            };
        }
    }
}
