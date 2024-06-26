﻿using Microsoft.Extensions.DependencyInjection;
using NotificationService.Application.Interfaces.NotificationTemplate;
using NotificationService.Application.Interfaces.SendNotification;
using NotificationService.Application.RabitMQ;
using NotificationService.Application.Services;
using NotificationService.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Application.DI
{
    public static class ApplicationSetup
    {
        public static void InstallApplication(this IServiceCollection services)
        {
            services.AddMediatR(m => m.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddScoped<INotificationTemplateService, NotificationTemplateService>();
            services.AddSingleton<JSonUtility>();
            services.AddSingleton<StringUtility>();
            services.AddScoped<ISmtpEmailSender, SmtpEmailSender>();
            services.AddScoped<ISMSSender, SMSSender>();
            services.AddScoped<IMessageReceiver, MessageReceiver>();

        }
    }
}
