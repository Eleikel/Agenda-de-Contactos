using AgendaTelefonica.Core.Application.Interfaces.Services;
using AgendaTelefonica.Core.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AgendaTelefonica.Core.Application
{

    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            #region Services
            services.AddTransient(typeof(IGenericService<,,>), typeof(GenericService<,,>));
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IPhoneService, PhoneService>();
            services.AddTransient<IUserService, UserService>();
            #endregion
        }

    }
}
