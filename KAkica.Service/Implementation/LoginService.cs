using AutoMapper;
using KAkica.Communication.AppUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using KAkica.Communication.Auth;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using KAkica.Domain.Models;

namespace KAkica.Service.Implementation
{
    public class LoginService
    {
        private UserManager<KakicaUser> m_userManager;
        private IConfiguration m_configuration;

        public LoginService(UserManager<KakicaUser> userManager, IConfiguration configuration)
        {
            m_userManager = userManager;
            m_configuration = configuration;
        }

        public async Task<AuthResponse> Login(string username, string email, string password)
        {
            var user = 
                await m_userManager.FindByNameAsync(username) ?? 
                await m_userManager.FindByEmailAsync(email);
            if (user != null && await m_userManager.CheckPasswordAsync(user, password))
            {
                var claim = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Username)
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
