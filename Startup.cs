using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetcore_configurations.Models.Configuration;
using dotnetcore_configurations.Services.Implementations;
using dotnetcore_configurations.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace dotnetcore_configurations
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.Configure<DashboardHeaderConfiguration>(this._configuration.GetSection("DashboardSettings:Header"));

            services.AddSingleton<IConfigurationReader, ConfigurationReader>();

            services.Configure<NormalThemeDashboardSettings>(_configuration.GetSection("DashboardThemeSettings:NormalTheme"));
            services.Configure<DarkThemeDashboardSettings>(_configuration.GetSection("DashboardThemeSettings:DarkTheme"));

            services.AddSingleton<IThemeConfigurationReader, ThemeConfigurationReader>();

            services.Configure<DashboardThemeSettings>("Normal", _configuration.GetSection("DashboardThemeSettings:NormalTheme"));
            services.Configure<DashboardThemeSettings>("Dark", _configuration.GetSection("DashboardThemeSettings:DarkTheme"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    "DefaultRoute",
                    "{controller=Dashboard2}/{action=Index}/{id?}"
                );
            });
        }
    }
}
