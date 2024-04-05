using DevTubeCommerce.Domain.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Domain.Notification
{
    public class NotificationTemplate : AggregateRoot<NotificationTemplateId>
    {
        #region Properties
        public string NotificationTemplateName { get; set; } //globally unique
        public string Template { get; set; } // example :hi dear $user.fullname , your code is : %token1
        public string InternalTokens { get; set; } // %user.fullname
        public string ExternalTokens { get; set; } //%token1
        public string LimitedToDelivaryTypes { get; set; } 
        #endregion

        #region Methods

        public static NotificationTemplate CreateNew(string NotificationTemplateName, string template, string internalTokens, string externalTokens, string limitedToDelivaryTypes)
        {
            var NotificationTemplateId = new NotificationTemplateId(Guid.NewGuid());
            return new NotificationTemplate(NotificationTemplateId, NotificationTemplateName, template, internalTokens, externalTokens, limitedToDelivaryTypes);
        }

        public static NotificationTemplate CreateNewForDelete(NotificationTemplateId id)
        {
            return new NotificationTemplate(id);
        }

        public void Update(NotificationTemplate newValue)
        {
            NotificationTemplateName = newValue.NotificationTemplateName;
            Template = newValue.Template;
            InternalTokens = newValue.InternalTokens;
            ExternalTokens = newValue.ExternalTokens;
            LimitedToDelivaryTypes = newValue.LimitedToDelivaryTypes;
        }
        
	#endregion

        #region Ctors
        public NotificationTemplate(NotificationTemplateId id,string notificationTemplateName, string template, string internalTokens, string externalTokens, string limitedToDelivaryTypes)
        {
            Id = id;
            NotificationTemplateName = notificationTemplateName;
            Template = template;
            InternalTokens = internalTokens;
            ExternalTokens = externalTokens;
            LimitedToDelivaryTypes = limitedToDelivaryTypes;
        }

        public NotificationTemplate(NotificationTemplateId id)
        {
            Id = id;
        }

        private NotificationTemplate()
        {
            //for EF
        } 
        #endregion
    }
}
