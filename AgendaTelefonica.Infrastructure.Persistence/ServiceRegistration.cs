using AgendaTelefonica.Core.Application.Interfaces.Repositories;
using AgendaTelefonica.Infrastructure.Persistence.Contexts;
using AgendaTelefonica.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaTelefonica.Infrastructure.Persistence
{

    public static class ServiceRegistration
    {

        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            #region Contexts


            services.AddDbContext<ApplicationContext>(options =>
            {
                options.EnableSensitiveDataLogging();
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                m => m.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName));
            });

            #endregion

            #region Repositories
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IPhoneRepository, PhoneRepository>();
            services.AddTransient<IEmailRepository, EmailRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            #endregion
        }
    }
}

