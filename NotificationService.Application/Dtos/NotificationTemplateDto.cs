using NotificationService.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Application.Dtos
{
    public class NotificationTemplateDto
    {
        public string NotificationTemplateName { get; set; } //globally unique
        public string Template { get; set; } // example :hi dear $user.fullname , your code is : %token1
        public List<string> InternalTokens { get; set; } // %user.fullname
        public List<string> ExternalTokens { get; set; } //%token1
        public List<DelivaryType> LimitedToDelivaryTypes { get; set; }
    }
}
