using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Prova.MedGrupo.Application.Interfaces;
using Prova.MedGrupo.Application.Services;
using Prova.MedGrupo.Data.Contexts;
using Prova.MedGrupo.Data.Repositories;
using Prova.MedGrupo.Data.UnitOfWork;
using Prova.MedGrupo.Domain.Interfaces;
using Prova.MedGrupo.Domain.Validations;
using Prova.MedGrupo.Framework.Interfaces;
using Prova.MedGrupo.Framework.Interfaces.Data;
using Prova.MedGrupo.Framework.Notifications;

namespace Prova.MedGrupo.Infra.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static IServiceCollection AddContextConfiguration(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ProvaMedGrupoDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            return services;
        }

        public static IServiceCollection AddApiConfiguration(IServiceCollection services)
        {
            services.AddScoped<INotificationContext, NotificationContext>();
            services.AddScoped<IUnitOfWork, ProvaMedGrupoUnitOfWork>();
            services.AddScoped<IContatoRepository, ContatoRepository>();
            services.AddTransient<IContatoValidations, ContatoValidations>();
            services.AddTransient<IContatosAppService, ContatosAppService>();
            return services;
        }
    }
}