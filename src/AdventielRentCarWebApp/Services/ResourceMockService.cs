using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace AdventielRentCarWebApp.Services
{
    public class ResourceMockService : IResourceService
    {
        public IList<T> Load<T>(string resourceName)
        {
            var fileName = $@"Mocks\{resourceName}".Split('.')[0] + ".json";
            using (var file = File.OpenRead(fileName))
            {
                using (var streamReader = new StreamReader(file))
                {
                    var stringify = streamReader.ReadToEnd();
                    var contractResolver = new DefaultContractResolver {NamingStrategy = new SnakeCaseNamingStrategy()};
                    var settings = new JsonSerializerSettings {ContractResolver = contractResolver};
                    return JsonConvert.DeserializeObject<List<T>>(stringify, settings);
                }
            }
        }
    }
}
