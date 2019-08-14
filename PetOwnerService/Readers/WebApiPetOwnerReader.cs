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
        private readonly string _endpoint;
        private readonly ILogger<WebApiPetOwnerReader> _log;

        public WebApiPetOwnerReader(string endpoint, ILogger<WebApiPetOwnerReader> log)
        {
            _endpoint = endpoint;
            _log = log;
        }

        public async Task<IEnumerable<PetOwner>> ReadPetOwners()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(_endpoint);

                    response.EnsureSuccessStatusCode();

                    var stringResult = await response.Content.ReadAsStringAsync();
                    _log.LogInformation($"PetOwner information retrieved from {_endpoint}");
                    var ownerList = JsonConvert.DeserializeObject<List<PetOwner>>(stringResult);
                    _log.LogInformation($"PetOwner information deserialised");
                    return ownerList;
                }
                catch (Exception e)
                {
                    _log.LogError(e, "Unhandled exception in WebApiPetOwnerReader.ReadPetOwners");
                    throw;
                }
            }
        }
    }
}
