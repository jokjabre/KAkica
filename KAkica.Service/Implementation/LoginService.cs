using AutoMapper;
using KAkica.Communication.AppUser;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using KAkica.Communication.Auth;

namespace KAkica.Service.Implementation
{
    public class LoginService
    {
        private UserManager<IdentityUser> m_userManager;
        private IConfiguration m_configuration;
        private IMapper m_mapper;

        public LoginService(UserManager<IdentityUser> userManager, IConfiguration configuration, IMapper mapper)
        {
            m_userManager = userManager;
            m_configuration = configuration;
            m_mapper = mapper;
        }

        public async Task<AppUserResponse> Register(AppUserRequest request)
        {
            var user = new IdentityUser
            {
                Email = request.Email,
                UserName = request.Username,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var result = await m_userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                await m_userManager.AddToRoleAsync(user, UserRoles.Owner.ToString());

                return m_mapper.Map<AppUserResponse>(user);
            }

            return null;
        }

        public async Task<AuthResponse> Login(AuthRequest request)
        {
            var user = 
                await m_userManager.FindByNameAsync(request.Username) ?? 
                await m_userManager.FindByEmailAsync(request.Username);
            if (user != null && await m_userManager.CheckPasswordAsync(user, request.Password))
            {
                var claim = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName)
                };
                var signinKey = new SymmetricSecurityKey(
                  Encoding.UTF8.GetBytes(m_configuration["Jwt:SigningKey"]));

                int expiryInMinutes = Convert.ToInt32(m_configuration["Jwt:ExpiryInMinutes"]);

                var token = new JwtSecurityToken(
                  issuer: m_configuration["Jwt:Site"],
                  audience: m_configuration["Jwt:Site"],
                  expires: DateTime.UtcNow.AddMinutes(expiryInMinutes),
                  signingCredentials: new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256)
                );

                return new AuthResponse
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Expiration = token.ValidTo
                };
            }
            return null;
        }
    }
}
