using DevTubeCommerce.Domain.Core.Base;
using NotificationService.Application.Interfaces.SendNotification;
using NotificationService.Application.Utilities;
using NotificationService.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Application.Services
{
    public class SMSSender : ISMSSender
    {
        private readonly IUserService _userService;
        private readonly StringUtility _stringUtility;

        private readonly HttpClient _httpClient;
        private readonly string _apiKey;


        public SMSSender(IUserService userService, StringUtility stringUtility)
        {
            _userService = userService;
            _stringUtility = stringUtility;
        }

        public async Task SendSmsAsync(Guid userId, string template, Dictionary<string, string> externalTokens)
        {
            var user = await _userService.GetUserByIdAsync(userId);

            if (user == null)
                throw new ApplicationException($"User with id {userId} not found.");

            Dictionary<string, string> internalTokens = await _userService.GenerateInternalTokens(userId);

            string message = _stringUtility.ReplaceTokens(template,internalTokens,externalTokens);

            var url = "https://api.kavenegar.com/v1/" + _apiKey + "/sms/send.json";
            var requestData = new
            {
                receptor = user.PhoneNumber,
                message = message
            };
            var requestDataJson = Newtonsoft.Json.JsonConvert.SerializeObject(requestData);
            var content = new StringContent(requestDataJson, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
            }
            else
            {
                throw new ApplicationException("Failed to send SMS. Status code: " + response.StatusCode);
            }
        }
    }
}