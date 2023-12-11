using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using API.Dtos;
using API.Helpers;
using API.Services;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Persistence.Data;

namespace API.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public UserService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, IMapper mapper, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _configuration = configuration;
        }

        public string GetMyName()
        {
            var result = string.Empty;
            if(_httpContextAccessor.HttpContext is not null)
            {
                result = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
            }
            return result;
        }
        public async Task<string> RegisterAsync(UserRegisterDto registerDto)
        {
            var user = new User
            {
                Username = registerDto.Username,
                Password = BCrypt.Net.BCrypt.HashPassword(registerDto.Password),
                Email = registerDto.Email
            };

            var existingUser = _unitOfWork.Users
                                .Find(u => u.Username.ToLower() == registerDto.Username.ToLower())
                                .FirstOrDefault();
            if (existingUser == null)
            {
                var rolDefault = _unitOfWork.Rols
                                .Find(u => u.Name == Authorization.rol_default.ToString())
                                .First();
                try
                {
                    user.Rols.Add(rolDefault);
                    _unitOfWork.Users.Add(user);
                    await _unitOfWork.SaveAsync();
                    return $"User {registerDto.Username} has been registered successfully";
                }
                catch (Exception ex)
                {
                        var message = ex.Message;
                        return $"Error: {message}";
                }
            }
            else
            {
                return $"User {registerDto.Username} already registered.";
            }
        }

        private RefreshToken GenerateRefreshToken()
        {
            var refreshToken = new RefreshToken
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Expires = DateTime.Now.AddDays(7)
            };

            return refreshToken;
        }

        private CookieOptions SetRefreshToken(RefreshToken newRefreshToken, User user)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = newRefreshToken.Expires
            };
            user.RefreshToken = newRefreshToken.Token;
            _httpContextAccessor.HttpContext.Response.Cookies.Append("refreshToken", newRefreshToken.Token, cookieOptions);
            user.TokenCreated = newRefreshToken.Created;
            user.TokenExpires = newRefreshToken.Expires;
            return cookieOptions;
        }

        public async Task<string> LoginAsync(UserDto request)
        {
        var existingUser = await _unitOfWork.Users.GetByUsernameAsync(request.Username);

        if (existingUser == null)
        {
            return "User not found.";
        }

        if (!BCrypt.Net.BCrypt.Verify(request.Password, existingUser.Password))
        {
            return "Wrong password.";
        }

        var refreshToken = GenerateRefreshToken();
        string token = await CreateToken(existingUser);
        existingUser.RefreshToken = refreshToken.Token;
        existingUser.TokenCreated = DateTime.Now;
        existingUser.TokenExpires = DateTime.Now.AddHours(1);
        SetRefreshToken(refreshToken, existingUser);
        _unitOfWork.Users.Update(existingUser);
        await _unitOfWork.SaveAsync();
        return token;
        }
        

        public async Task<string> RefreshToken(string Username)
        {
            var refreshTokenCookie = _httpContextAccessor.HttpContext.Request.Cookies["refreshToken"];
            var existingUser = await _unitOfWork.Users.GetByUsernameAsync(Username);
            var refreshToken = existingUser.RefreshToken;
            if (existingUser == null)
            {
                return "User not found.";
            }
            if (!refreshToken.Equals(refreshTokenCookie))
            {
                return "Invalid Refresh Token";
            }
            else if (existingUser.TokenExpires < DateTime.Now)
            {
                return "Token expired";
            }
            string token = await CreateToken(existingUser);
            var newRefreshToken = GenerateRefreshToken();
            SetRefreshToken(newRefreshToken, existingUser);
            return token;
        }

        public async Task<string> CreateToken(User user)
        {
            var claims = new List<Claim> {
                new Claim(ClaimTypes.Name, user.Username)
            };
            var userMapped = _mapper.Map<UserDto>(user);
            var roles = await GetTokenAsync(userMapped);
            foreach (string rol in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, rol ));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
        public async Task<List<string>> GetTokenAsync(UserDto model)
        {
            var user = await _unitOfWork.Users.GetByUsernameAsync(model.Username);
            var roles = user.Rols
                            .Select(u => u.Name)
                            .ToList();
            return roles;
        }
        public async Task<string> AddRolAsync(UserRolDto model)
        {
            var user = await _unitOfWork.Users.GetByUsernameAsync(model.Username);
            try
            {
                var rol = _unitOfWork.Rols
                                    .Find(u => u.Name == model.Rol)
                                    .First();
                user.Rols.Add(rol);
                _unitOfWork.Users.Update(user);
                await _unitOfWork.SaveAsync();
                return $"Rol {rol.Name} add succesfully to {user.Username}";
            }
            catch (Exception ex)
                {
                        var message = ex.Message;
                        return $"Error: {message}";
                }
        }

    }
}