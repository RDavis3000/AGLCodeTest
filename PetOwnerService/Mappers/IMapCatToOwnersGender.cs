using System.Collections.Generic;
using PetOwnerModels;

namespace PetOwnerService.PetOwnerProcessors
{
    public interface IMapCatToOwnersGender
    {
        Dictionary<string, List<string>> Process(IEnumerable<PetOwner> petOwners);
    }
}