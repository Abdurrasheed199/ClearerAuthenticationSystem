using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
//using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AuthService : IAuthService
    {

        private readonly IAuthRepository _authRepository;
        private readonly IJwtService _jwtService;
        private readonly PasswordHasher _passwordHasher;

        public AuthService(
            IAuthRepository authRepository,
            IJwtService jwtService,
            PasswordHasher passwordHasher)
        {
            _authRepository = authRepository;
            _jwtService = jwtService;
            _passwordHasher = passwordHasher;
        }

        public async Task<AuthResponseDto> LoginAsync(LoginUserDto userDto)
        {
            var user = await _authRepository.GetUserByUsernameAsync(userDto.Username);
            if (user == null || !_passwordHasher.VerifyPassword(userDto.Password, user.PasswordHash))
                throw new UnauthorizedAccessException("Invalid username or password");

            var token = _jwtService.GenerateToken(user);

            //return new AuthResponseDto(token, user.Username);

            return new AuthResponseDto
            {
                Token = token,
                Username = user.Username,
                ExpiresAt = DateTime.UtcNow.AddHours(24)
            };
        }
        

        public async Task<AuthResponseDto> RegisterAsync(RegisterUserDto userDto)
        {
            var existingUser = await _authRepository.GetUserByUsernameAsync(userDto.Username);
            if (existingUser != null)
                throw new ArgumentException("Username already exists");

            var user = new User
            {
                Username = userDto.Username,
                Email = userDto.Email,
                PasswordHash = _passwordHasher.HashPassword(userDto.Password)
            };

            var token = _jwtService.GenerateToken(user);

            await _authRepository.CreateUserAsync(user);

            //return new AuthResponseDto(_jwtService.GenerateToken(user), user.Username);

            return new AuthResponseDto
            {
                Token = token,
                Username = user.Username,
                ExpiresAt = DateTime.UtcNow.AddHours(24)
            };
        }
    }
}
