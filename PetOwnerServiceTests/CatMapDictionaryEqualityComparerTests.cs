using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetOwnerServiceTests.EqualityComparers;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetOwnerServiceTests
{
    [TestClass]
    public class CatMapDictionaryEqualityComparerTests
    {
        [TestMethod]
        public void TestSameDictionary()
        {
            //arrange
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

            var dictionaryEqualityComparer = new CatMapDictionaryEqualityComparer();

            //act
            var areEqual = dictionaryEqualityComparer.Equals(expectedresult, expectedresult2);

            //assert
            Assert.IsTrue(areEqual);

        }

        [TestMethod]
        public void TestSameDictionaryDifferentValueOrder()
        {
            //arrange
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
                    "bzPet5",
                    "abPet4",
                    "aPet1",                    
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

            var dictionaryEqualityComparer = new CatMapDictionaryEqualityComparer();

            //act
            var areEqual = dictionaryEqualityComparer.Equals(expectedresult, expectedresult2);

            //assert
            Assert.IsFalse(areEqual);

        }


        [TestMethod]
        public void TestSameDictionaryDifferentValues()
        {
            //arrange
            var expectedresult = new Dictionary<string, List<string>>()
            {

                {"Gender1", new List<string>()
                {
                    "abPet4",
                    "aPet1",
                    "bzPet5",
                    "dupe1",
                    "NEWVAL"
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
                    "bzPet5",
                    "abPet4",
                    "aPet1",
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

            var dictionaryEqualityComparer = new CatMapDictionaryEqualityComparer();

            //act
            var areEqual = dictionaryEqualityComparer.Equals(expectedresult, expectedresult2);

            //assert
            Assert.IsFalse(areEqual);

        }

        [TestMethod]
        public void TestDifferentGenderKeys()
        {
            //arrange
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

                {"GenderX", new List<string>()
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

            var dictionaryEqualityComparer = new CatMapDictionaryEqualityComparer();

            //act
            var areEqual = dictionaryEqualityComparer.Equals(expectedresult, expectedresult2);

            //assert
            Assert.IsFalse(areEqual);

        }

        [TestMethod]
        public void TestDifferentKeyCount()
        {
            //arrange
            var expectedresult = new Dictionary<string, List<string>>()
            {

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

            var dictionaryEqualityComparer = new CatMapDictionaryEqualityComparer();

            //act
            var areEqual = dictionaryEqualityComparer.Equals(expectedresult, expectedresult2);

            //assert
            Assert.IsFalse(areEqual);

        }

    }
}
