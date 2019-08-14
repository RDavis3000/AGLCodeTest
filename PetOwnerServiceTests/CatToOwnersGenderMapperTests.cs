using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using PetOwnerModels;
using PetOwnerService.PetOwnerProcessors;
using PetOwnerServiceTests.EqualityComparers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetOwnerServiceTests
{
    [TestClass]
    public class CatToOwnersGenderMapperTests
    {

        [TestMethod]
        public void TestProcess()
        {

            //Arrange

            var processCatsAlphaOwnerGender = new CatToOwnersGenderMapper();

            List<PetOwner> testData = new List<PetOwner>()
            {
                new PetOwner()
                {
                    Gender="Gender1",
                    Pets = new List<Pet>()
                    {
                        new Pet()
                        {
                            Name="aPet1",
                            Type="Cat"
                        },
                        new Pet()
                        {
                            Name="dupe1",
                            Type="Cat"
                        },
                        new Pet()
                        {
                            Name="cPet3",
                            Type="Type2"
                        }
                    }
                },
                new PetOwner()
                {
                    Gender="Gender1",
                    Pets = new List<Pet>()
                    {
                        new Pet()
                        {
                            Name="abPet4",
                            Type="Cat"
                        },
                        new Pet()
                        {
                            Name="bzPet5",
                            Type="Cat"
                        },
                        new Pet()
                        {
                            Name="caPet6",
                            Type="Type2"
                        }
                    }
                },
                new PetOwner()
                {
                    Gender="Gender2",
                    Pets = new List<Pet>()
                    {
                        new Pet()
                        {
                            Name="dupe1",
                            Type="Cat"
                        },
                        new Pet()
                        {
                            Name="bPet7",
                            Type="Cat"
                        },
                        new Pet()
                        {
                            Name="bPet8",
                            Type="Cat"
                        },

                    }
                },
            };

            var expectedresult = new Dictionary<string, List<string>>()
            {

                {"Gender1", new List<string>()
                {
                    "abPet4",
                    "aPet1",
                    "bzPet5",
                    "dupe1"
                }
                },
                {"Gender2", new List<string>()
                {
                   "bPet7",
                   "bPet8",
                   "dupe1"
                }
                }
            };

            //Act

            var actualResult = processCatsAlphaOwnerGender.Process(testData);

            var dictionaryEqualityComparer = new CatMapDictionaryEqualityComparer();

            var areEqual = dictionaryEqualityComparer.Equals(actualResult, expectedresult);            

            //Assert
            Assert.IsTrue(areEqual);
        }
    }
}
