using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetOwnerServiceTests.EqualityComparers
{
    public class CatMapDictionaryEqualityComparer : IEqualityComparer<Dictionary<string, List<string>>>
    {
        public bool Equals(Dictionary<string, List<string>> x, Dictionary<string, List<string>> y)
        {
            try
            {
                if(x == null || y== null)
                {
                    return false;
                }

                //list of keys should be identical
                if(!x.Keys.SequenceEqual(y.Keys))
                {
                    return false;
                }

                bool kvpEquals = true;
                var catListEqualityComparer = new CatMapKVPEqualityComparer();


                for(int i=0;i<x.Count;i++)
                {
                    var xKvp = x.ElementAtOrDefault(i);
                    var yKvp = y.ElementAtOrDefault(i);
                    kvpEquals &= catListEqualityComparer.Equals(xKvp, yKvp);
                }

                return kvpEquals;
            }
            catch(NullReferenceException)
            {
                return false;
            }

        }

        public int GetHashCode(Dictionary<string, List<string>> obj)
        {
            throw new NotImplementedException();
        }
    }
}
