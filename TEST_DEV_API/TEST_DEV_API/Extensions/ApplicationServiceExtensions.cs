using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TEST_DEV.Data.Data;
using TEST_DEV_API.Interfaces;
using TEST_DEV_API.Models;
using TEST_DEV_API.Services;

namespace TEST_DEV_API.Extensions
{
    public static class AplicationServiceExtensions
    {
        public static IServiceCollection AddAplicationServices(this IServiceCollection services,
                                                                IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });
            services.AddDbContext<SPDbContext>(options =>
            options.UseSqlServer(config.GetConnectionString("DefaultConnection"))
            );
            services.AddCors();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IPersonaFisicaRepository, PersonaFisicaRepository>();


            return services;
        }
    }
}
