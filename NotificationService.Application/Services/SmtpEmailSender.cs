using NotificationService.Application.Interfaces.SendNotification;
using NotificationService.Application.Utilities;
using NotificationService.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Application.Services
{
    public class SmtpEmailSender : ISmtpEmailSender
    {
        private readonly SmtpClient _smtpClient;
        private readonly IUserService _userService;
        private readonly StringUtility _stringUtility;

        public SmtpEmailSender(SmtpClient smtpClient, IUserService userService, StringUtility stringUtility)
        {
            _smtpClient = smtpClient;
            _userService = userService;
            _stringUtility = stringUtility;
        }

        public async Task SendEmailAsync(Guid userId, string template, Dictionary<string, string> externalTokens)
        {
            var user = await _userService.GetUserByIdAsync(userId);

            if (user == null)
                throw new ApplicationException($"User with id {userId} not found.");

            Dictionary<string, string> internalTokens = await _userService.GenerateInternalTokens(userId);

            var emailText = _stringUtility.ReplaceTokens(template, internalTokens,externalTokens);

            var mailMessage = new MailMessage
            {
                From = new MailAddress("your@email.com"),
                Body = emailText,
                IsBodyHtml = true
            };
            mailMessage.To.Add(user.Email);

            await _smtpClient.SendMailAsync(mailMessage);

        }
    }
}
