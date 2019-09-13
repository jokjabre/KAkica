using JokJaBre.Core.Objects;
using JokJaBre.Core.API.Extensions;
using KAkica.Domain.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System.Net;
using KAkica.API.Services;
using JokJaBre.Core;
using JokJaBre.Core.Identity.Extensions;

namespace KAkica_API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)

        {
            services.AddDbContext<DbContext, KAkicaDbContext>(opts => 
                opts.UseSqlServer(Configuration.GetConnectionString("KAkicaDbContext")));

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2) ;

            //scoped services
            services.AddJokJaBreScopedModel<Pooper, PooperService>();
            services.AddJokJaBreScopedModel<KakicaUser>();
            services.AddJokJaBreScopedModel<Owner>();
            services.AddJokJaBreScopedModel<Activity>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });

            services.AddJokJaBreIdentity<KAkicaDbContext>();

           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseAuthentication();

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
