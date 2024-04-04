using Microsoft.Extensions.DependencyInjection;
using NotificationService.Domain.Notification;
using NotificationService.Infrastructure.Patterns;
using NotificationService.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Infrastructure.DI
{
    public static class InfrastructureSetup
    {
        public static void InstallInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<INotificationTemplateRepository,NotificationTemplateRepository>();

        }
    }
}
