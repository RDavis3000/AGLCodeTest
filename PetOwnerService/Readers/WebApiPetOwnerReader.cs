using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PetOwnerModels;

namespace PetOwnerService.Readers
{
    public class WebApiPetOwnerReader : IReadPetOwners
    {
        private readonly string endpoint;
        private readonly ILogger<WebApiPetOwnerReader> log;

        public WebApiPetOwnerReader(string endpoint, ILogger<WebApiPetOwnerReader> log)
        {
            this.endpoint = endpoint;
            this.log = log;
        }

        public async Task<IEnumerable<PetOwner>> ReadPetOwners()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(endpoint);

                    response.EnsureSuccessStatusCode();

                    var stringResult = await response.Content.ReadAsStringAsync();
                    log.LogInformation($"PetOwner information retrieved from {endpoint}");
                    var ownerList = JsonConvert.DeserializeObject<List<PetOwner>>(stringResult);
                    log.LogInformation($"PetOwner information deserialised");
                    return ownerList;
                }
                catch (Exception e)
                {
                    log.LogError(e, "Unhandled exception in WebApiPetOwnerReader.ReadPetOwners");
                    throw;
                }
            }
        }
    }
}
