using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PetOwnerModels;
using PetOwnerService;
using PetOwnerService.PetOwnerProcessors;
using PetOwnerService.Readers;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetOwnerServiceTests
{
    [TestClass]
    public class CatsAlphaOwnerGenderServiceTest
    {

        [TestMethod]
        public async void GetCatsAlphaOwnerGenderDictionaryTest()
        {
            //arrange
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
                   "aPet1",
                   "abPet4",
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

            var IReadPetOwnersMock = new Mock<IReadPetOwners>();

            IReadPetOwnersMock.Setup(p => p.ReadPetOwners()).ReturnsAsync(testData);

            var ownerProcessor = new ProcessCatsAlphaOwnerGender();

            var catsAlphaOwnerGenderService = new CatsAlphaOwnerGenderService(IReadPetOwnersMock.Object, ownerProcessor);

            //act
            var result = await catsAlphaOwnerGenderService.GetCatsAlphaOwnerGenderDictionaryAsync();

            //assert
            Assert.AreEqual(result, expectedresult);
        }
    }
}
