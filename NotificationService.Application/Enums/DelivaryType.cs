using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Application.Enums
{
    [Flags]
    public enum DelivaryType
    {
        SMS = 10,
        EMail = 20
    }
}
