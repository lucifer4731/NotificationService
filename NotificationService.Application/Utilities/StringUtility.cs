using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Application.Utilities
{
    public class StringUtility
    {
        public string ReplaceTokens(string message, Dictionary<string, string> internalTokens, Dictionary<string, string> externalTokens)
        {
            foreach (var token in internalTokens)
            {
                message = message.Replace("%" + token.Key + "%", token.Value);
            }

            foreach (var token in externalTokens)
            {
                message = message.Replace("%" + token.Key + "%", token.Value);
            }

            return message;
        }
    }
}
