using MedicoApp.Core.Application.Interfaces.Repositories;
using MedicoApp.Core.Application.Interfaces.Services;
using MedicoApp.Core.Application.Services;
using MedicoApp.Infrastructure.Persistence.Contexts;
using MedicoApp.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoApp.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            #region Contexts
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationContext>(options => options.UseInMemoryDatabase("ApplicationDb"));
            }
            else
            {
                services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                m => m.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));
            }
            #endregion

            #region Repositories
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IMedicoRepository, MedicoRepository>();
            services.AddTransient<IPacientesRepository, PacienteRepository>();
            services.AddTransient<IPruebaDeLabRepository, PruebaDeLabRepository>();
            services.AddTransient<ICitasRepository, CitasRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IResultDeLabRepository, ResultDeLabRepository>();
            #endregion
        }
    }
}
