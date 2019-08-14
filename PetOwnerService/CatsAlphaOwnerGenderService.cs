using PetOwnerModels;
using PetOwnerService.PetOwnerProcessors;
using PetOwnerService.Readers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetOwnerService
{
    public class CatsAlphaOwnerGenderService
    {
        private readonly IReadPetOwners readPetOwners;
        private readonly PetOwnerProcessors.IProcessCatsAlphaOwnerGender processCatsAlphaOwnerGender;

        public CatsAlphaOwnerGenderService(IReadPetOwners readPetOwners, IProcessCatsAlphaOwnerGender processCatsAlphaOwnerGender)
        {
            this.readPetOwners = readPetOwners;
            this.processCatsAlphaOwnerGender = processCatsAlphaOwnerGender;
        }

        public async Task<Dictionary<string,IEnumerable<string>>>  GetCatsAlphaOwnerGenderDictionary()
        {
            var petOwners = await readPetOwners.ReadPetOwners();

            var processedResults = processCatsAlphaOwnerGender.Process(petOwners);

            return processedResults;

        }
    }
}
