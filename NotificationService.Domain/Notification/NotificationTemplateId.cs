using DevTubeCommerce.Domain.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Domain.Notification
{
    public sealed class NotificationTemplateId : StronglyTypedId<NotificationTemplateId>
    {
        public NotificationTemplateId(Guid value) : base(value)
        {
            
        }
    }
}
