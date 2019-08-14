using System.Collections.Generic;
using PetOwnerModels;

namespace PetOwnerService.PetOwnerProcessors
{
    public interface IProcessCatsAlphaOwnerGender
    {
        Dictionary<string, IEnumerable<string>> Process(IEnumerable<PetOwner> petOwners);
    }
}