using System.Reflection;
using AutoMapper;
using Prova.MedGrupo.Data.Contexts;
using Prova.MedGrupo.Infra.IoC;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Xunit;
using Xunit.Abstractions;
using Xunit.DependencyInjection;
using System;

[assembly: TestFramework("Prova.MedGrupo.Tests.Startup", "Prova.MedGrupo.Tests")]
namespace Prova.MedGrupo.Tests
{
    public class Startup : DependencyInjectionTestFramework
    {
        public Startup(IMessageSink messageSink)
        : base(messageSink)
        {
        }

        protected void ConfigureServices(IServiceCollection services)
        {
            // Context Config
            ConfigureDbContext(services);
            // Dependencies Config
            NativeInjectorBootStrapper.AddApiConfiguration(services);
            // AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        protected override IHostBuilder CreateHostBuilder(AssemblyName assemblyName) =>
            base.CreateHostBuilder(assemblyName)
                .ConfigureServices(ConfigureServices);

        private void ConfigureDbContext(IServiceCollection services)
        {
            services.AddDbContext<ProvaMedGrupoDbContext>(options =>
            {
                options.UseInMemoryDatabase("Prova.MedGrupo");
            });
        }
    }
}