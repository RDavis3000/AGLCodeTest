using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PetOwnerModels;
using PetOwnerService;
using PetOwnerService.PetOwnerProcessors;
using PetOwnerService.Readers;
using PetOwnerServiceTests.EqualityComparers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetOwnerServiceTests
{
    [TestClass]
    public class GetCatMapServiceTests
    {
        [TestMethod]
        public async Task GetCatMapDictionaryAsyncTest()
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

            var ILoggerMock = new Mock<ILogger<GetCatMapService>>();

            var IReadPetOwnersMock = new Mock<IReadPetOwners>();

            IReadPetOwnersMock.Setup(p => p.ReadPetOwners()).ReturnsAsync(testData);

            var ownerProcessor = new CatToOwnersGenderMapper();

            var catsAlphaOwnerGenderService = new GetCatMapService(IReadPetOwnersMock.Object, ownerProcessor, ILoggerMock.Object);

            //act
            var actualResult = await catsAlphaOwnerGenderService.GetCatMapDictionaryAsync();

            var dictionaryEqualityComparer = new CatMapDictionaryEqualityComparer();

            var areEqual = dictionaryEqualityComparer.Equals(actualResult, expectedresult);

            //assert
            Assert.IsTrue(areEqual);
        }
    }
}
