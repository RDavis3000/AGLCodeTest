using Microsoft.Extensions.Logging;
using PetOwnerModels;
using PetOwnerService.PetOwnerProcessors;
using PetOwnerService.Readers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetOwnerService
{
    public class GetCatMapService
    {
        private readonly IReadPetOwners _readPetOwners;
        private readonly IMapCatToOwnersGender _catToOwnersGenderMapper;
        private readonly ILogger<GetCatMapService> _logger;

        public GetCatMapService(IReadPetOwners readPetOwners, IMapCatToOwnersGender catToOwnersGenderMapper, ILogger<GetCatMapService> logger)
        {
            _readPetOwners = readPetOwners;
            _catToOwnersGenderMapper = catToOwnersGenderMapper;
            _logger = logger;
        }

        public async Task<Dictionary<string, List<string>>> GetCatMapAsync()
        {
            try
            {
                _logger.LogInformation("GetCatMapAsync called");
                var petOwners = await _readPetOwners.ReadPetOwners();
                _logger.LogInformation($"GetCatMapAsync read complete {petOwners?.Count()} retrieved");
                var processedResults = _catToOwnersGenderMapper.Process(petOwners);
                _logger.LogInformation("GetCatMapAsync completed");
                return processedResults;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Unhandled Exception in GetCatMapService.GetCatMapAsync");
                throw;
            }
        }
    }
}
