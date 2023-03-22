using MedicoApp.Core.Application.Interfaces.Repositories;
using MedicoApp.Core.Application.Interfaces.Services;
using MedicoApp.Core.Application.Services;
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
        public static void AddApplicationLayer(this IServiceCollection services)
        {

            #region Services
            services.AddTransient<IMedicoService, MedicoService>();
            services.AddTransient<IPacientesService, PacientesService>();
            services.AddTransient<IPruebaDeLabService, PruebaDeLabService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ICitasService, CitasService>();
            services.AddTransient<IResultDeLabService, ResultDeLabService>();
            #endregion
        }
    }
}
