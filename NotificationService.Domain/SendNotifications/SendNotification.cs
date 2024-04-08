using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Domain.SendNotifications
{
    public class SendNotification
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string TemplateName { get; set; }
        public Dictionary<string, string> Tokens { get; set; }
    }
}
