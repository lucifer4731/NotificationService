using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Application.Base
{
    public class ApplicationExceprion : Exception
    {
        public ApplicationExceprion(string message) : base(message)
        {
            
        }
    }
}
