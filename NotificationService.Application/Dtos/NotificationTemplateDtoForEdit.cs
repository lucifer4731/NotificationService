using NotificationService.Application.Enums;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Application.Dtos
{
    public class NotificationTemplateDtoForEdit
    {
        [DataMember(Name = "NotificationTemplateId")]
        public Guid Id { get; set; }

        [DataMember(Name = "NotificationTemplateName")]
        public string NotificationTemplateName { get; set; }

        [DataMember(Name = "Template")]
        public string Template { get; set; }

        [DataMember(Name = "InternalTokens")]
        public List<string> InternalTokens { get; set; }

        [DataMember(Name = "ExternalTokens")]
        public List<string> ExternalTokens { get; set; }

        [DataMember(Name = "LimitedToDelivaryTypes")]
        [SwaggerSchema(Description = "Array of delivery types allowed for this template.")]
        public DelivaryType[] LimitedToDelivaryTypes { get; set; }
    }
}
