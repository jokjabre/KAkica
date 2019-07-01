using JokJaBre.Core.Objects.Service;
using JokJaBre.Core.Repository;
using JokJaBre.Core.Service;
using KAkica.Domain.Models;
using KAkica.Service.Implementation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAkica.API.Startup_Helpers
{
    public static class Helpers
    {
        public static void AddScopedServices(this IServiceCollection services)
        {
            services.AddTransient<IJokJaBreRepository<Pooper>, JokJaBreRepository<Pooper>>();
            services.AddTransient<IJokJaBreService<Pooper> , JokJaBreService<Pooper>>();

            services.AddTransient<LoginService>();
        }

        public static void AddJwt(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(option => {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options => {
                options.SaveToken = true;
                options.RequireHttpsMetadata = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = configuration["Jwt:Site"],
                    ValidIssuer = configuration["Jwt:Site"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SigningKey"]))
                };
            });
        }

        public static void AddIdentity(this IServiceCollection services)
        {
            services.AddIdentity<IdentityUser, IdentityRole>(option =>
            {
                option.Password.RequireDigit = false;
                option.Password.RequiredLength = 6;
                option.Password.RequireNonAlphanumeric = false;
                option.Password.RequireUppercase = false;
                option.Password.RequireLowercase = false;

                option.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<KAkicaDbContext>()
            .AddDefaultTokenProviders();
        }
    }
}
