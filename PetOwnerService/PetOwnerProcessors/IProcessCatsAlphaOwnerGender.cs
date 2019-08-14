using System.Collections.Generic;
using PetOwnerModels;

namespace PetOwnerService.PetOwnerProcessors
{
    public interface IProcessCatsAlphaOwnerGender
    {
        Dictionary<string, List<string>> Process(IEnumerable<PetOwner> petOwners);
    }
}