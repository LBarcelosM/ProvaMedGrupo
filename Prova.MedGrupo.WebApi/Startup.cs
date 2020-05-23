using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Prova.MedGrupo.Infra.IoC;
using Prova.MedGrupo.WebApi.Configuration;

namespace Prova.MedGrupo.WebApi
{
    public class Startup
    {
        public IConfiguration _configuration { get; }

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            // Context Configuration
            NativeInjectorBootStrapper.AddContextConfiguration(services, GetConnectionString());
            // Api Configuration
            services.AddApiConfiguration();
            // Swagger Configuration
            services.AddSwaggerConfiguration();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwaggerConfiguration();
            app.UseApiConfiguration(env);
        }

        private string GetConnectionString()
        {
            return _configuration.GetConnectionString("Default");
        }
    }
}
