using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetOwnerServiceTests.EqualityComparers
{
    public class CatMapKVPEqualityComparer : IEqualityComparer<KeyValuePair<string, List<string>>>
    {
        public bool Equals(KeyValuePair<string, List<string>> x, KeyValuePair<string, List<string>> y)
        {
            try
            {
                //compare the keys
                if (x.Key != y.Key)
                {
                    return false;
                }

                //compare the lists
                var compLists = x.Value.SequenceEqual(y.Value);
                return compLists;
            }
            catch(NullReferenceException e)
            {
                //if anything is null then return false
                return false;
            }
        }

        public int GetHashCode(KeyValuePair<string, List<string>> obj)
        {
            return obj.GetHashCode();
        }

    }
}
