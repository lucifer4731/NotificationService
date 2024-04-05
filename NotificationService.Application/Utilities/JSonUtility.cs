using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Application.Utilities
{
    public class JSonUtility
    {
        private readonly JsonSerializerSettings _settings = new()
        {
            Formatting = Formatting.Indented,
            ContractResolver = new DefaultContractResolver { NamingStrategy = new CamelCaseNamingStrategy()},
        };

        public string ConvertListToJson<T>(IEnumerable<T> list)
        {
            return JsonConvert.SerializeObject(list, _settings);
        }

        public IEnumerable<T> ConvertJsonToList<T>(string jSon)
        {
            return JsonConvert.DeserializeObject<IEnumerable<T>>(jSon, _settings);
        }
    }
}
