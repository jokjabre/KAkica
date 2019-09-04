using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using K_Akica.Blazor.Data;
using Microsoft.Net.Http.Headers;
using K_Akica.Blazor.Pages;
using K_Akica.Blazor.Data.ViewModels;
using EmbeddedBlazorContent;
using K_Akica.Blazor.Data.Helpers;
using MatBlazor;

namespace K_Akica.Blazor
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();

            services.AddSingleton<WeatherForecastService>();
            services.AddSingleton<HttpClientService>();

            services.AddTransient<PoopersViewModel>();

            services.AddHttpClient("kakica", c =>
            {
                c.BaseAddress = new Uri("http://localhost:52843/api/");

                c.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json; charset=UTF-8");
                c.DefaultRequestHeaders.Add(HeaderNames.UserAgent, "Kakica.Blazor");
            });

            services.AddMatToaster(config =>
            {
                config.Position = MatToastPosition.BottomCenter;
                config.ShowCloseButton = true;
                config.MaximumOpacity = 95;
                config.VisibleStateDuration = 2000;
                config.HideTransitionDuration = 100;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub<App>(selector: "app");
                endpoints.MapFallbackToPage("/_Host");
            });

            app.UseEmbeddedBlazorContent(typeof(MatBlazor.BaseMatComponent).Assembly);

        }
    }
}
