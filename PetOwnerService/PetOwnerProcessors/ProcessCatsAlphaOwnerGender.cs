using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetOwnerModels;

namespace PetOwnerService.PetOwnerProcessors
{ 
    public class ProcessCatsAlphaOwnerGender : IProcessCatsAlphaOwnerGender
    {        
        public Dictionary<string, IEnumerable<string>> Process(IEnumerable<PetOwner> petOwners)
        {
            try
            {
                var notNull = petOwners.Where(po => po.Pets != null);

                var catsOnly = notNull.SelectMany(po => po.Pets);

                //exclude non-cats first to improve performance in large sets and flatten into relevent information for this process            
                var releventRecordTuples = notNull.SelectMany(po => po.Pets.Where(pet => pet.Type.ToUpper() == "CAT"), (po, pt) => (OwnerGender: po.Gender, Pet: pt));

                //order by pet name
                var orderedReleventRecordTuples = releventRecordTuples.OrderBy(rt => rt.Pet.Name);

                //group by owner gender
                var genderGroups = releventRecordTuples.GroupBy(rr => rr.OwnerGender, rr => rr.Pet);

                //convert to dictionary and only keep the pet.name value            
                var outputDictionary = genderGroups.ToDictionary(grp => grp.Key, petList => petList.Select(pet => pet.Name));

                return outputDictionary;
            }
            catch(Exception e)
            {
                throw;
            }
        }
    }
}
