using PetOwnerModels;
using PetOwnerService.PetOwnerProcessors;
using PetOwnerService.Readers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetOwnerService
{
    public class GetCatMapService
    {
        private readonly IReadPetOwners _readPetOwners;
        private readonly IMapCatToOwnersGender _catToOwnersGenderMapper;

        public GetCatMapService(IReadPetOwners readPetOwners, IMapCatToOwnersGender catToOwnersGenderMapper)
        {
            _readPetOwners = readPetOwners;
            _catToOwnersGenderMapper = catToOwnersGenderMapper;
        }

        public async Task<Dictionary<string,List<string>>>  GetCatMapAsync()
        {
            var petOwners = await _readPetOwners.ReadPetOwners();

            var processedResults = _catToOwnersGenderMapper.Process(petOwners);

            return processedResults;

        }
    }
}
