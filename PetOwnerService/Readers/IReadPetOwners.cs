using PetOwnerModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetOwnerService.Readers
{
    public interface IReadPetOwners
    {
        Task<IEnumerable<PetOwner>> ReadPetOwners();
    }
}
