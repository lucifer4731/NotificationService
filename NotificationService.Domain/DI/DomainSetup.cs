using Microsoft.Extensions.DependencyInjection;
using NotificationService.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Domain.DI
{
    public static class DomainSetup
    {
        public static void InstallDomain(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();

        }
    }
}
