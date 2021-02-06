using NUnit.Framework;
using SilverhorseServiceHelpers.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverHorseBackendTests
{
    public class TestRandomListItems
    {

        public List<int> testList = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };


        [Test]
        public void TestDeserializer()
        {
            var randomList = new RandomListsItems();

            var returnedList = randomList.ReturnRandomList<int>(testList, 5).Result;

            Assert.True(returnedList.Count == 5);
        }
    }
}
