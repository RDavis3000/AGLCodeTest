using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetOwnerService
{
    public interface IGetCatMapService
    {
        Task<Dictionary<string, List<string>>> GetCatMapDictionaryAsync();
    }
}