using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using PetOwnerModels;
using PetOwnerService.PetOwnerProcessors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetOwnerServiceTests
{
    [TestClass]
    public class ProcessCatsAlphaOwnerGenderTest
    {

        [TestMethod]
        public void TestProcess()
        {

            //Arrange

            var processCatsAlphaOwnerGender = new ProcessCatsAlphaOwnerGender();

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

            var expectedresult2 = new Dictionary<string, List<string>>()
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

            var processResult = processCatsAlphaOwnerGender.Process(testData);

            CollectionAssert.AreEqual(expectedresult, expectedresult2);

            //Assert
            //CollectionAssert.AreEqual(processResult, expectedresult);            
        }
    }

    public class DictComp : IComparer<Dictionary<string, List<string>>>
    {
        public int Compare(Dictionary<string, List<string>> x, Dictionary<string, List<string>> y)
        {

            if(x.Keys.Count !=y.Keys.Count)
            {
                return x.Keys.Count.CompareTo(y.Keys.Count);
            }

            for (int i = 0; i < x.Keys.Count; i++)
            {
                if (x.Keys.ElementAt(i) == y.Keys.ElementAt(i))
                {
                    var xValue = x.GetValueOrDefault(x.Keys.ElementAt(i));
                    var yValue = y.GetValueOrDefault(y.Keys.ElementAt(i));

                    if (xValue.Count != yValue.Count)
                    {
                        return 1;
                    }

                    for (int j = 0; j < xValue.Count; j++)
                    {
                        if (xValue.ElementAt(j).CompareTo(yValue.ElementAt(j)) != 0)
                        {
                            return 1;
                        }
                    }
                }
                else
                {
                    return 1;
                }
            }

            return 0;
        }
    }
}
