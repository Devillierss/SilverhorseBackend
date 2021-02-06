using NUnit.Framework;
using SilverhorseDtos;
using SilverhorseServiceHelpers.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverHorseBackendTests
{
    public class TestClassSerializer
    {


        [Test]
        public void TestDeserializer()
        {
            var test = new Post() { Id = 1, UserId = 1, Body = "body", Title = "Title" };
            string testsonString = "{\"id\":1,\"userId\":1,\"title\":\"Title\",\"body\":\"body\"}";

            var result = new ClassSerializer().Deserialize<Post>(testsonString);

            Assert.True(test.Body == result.Body);
        }

        [Test]
        public void TestSerializer()
        {
            var result = new ClassSerializer().Serialize<Post>(new Post() { Id = 1, UserId = 1, Body = "body", Title = "Title"});
            string testResult = "{\"id\":1,\"userId\":1,\"title\":\"Title\",\"body\":\"body\"}";

            Assert.True(result == testResult);

        }
    }
}
