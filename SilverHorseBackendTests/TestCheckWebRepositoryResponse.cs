using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using SilverhorseServiceHelpers.Services;
using System.Net;
using System.Net.Http;

namespace SilverHorseBackendTests
{
    public class TestCheckWebRepositoryResponse
    {
       

        [Test]
        public void TestResponseReturnsOK()
        {
            HttpContent content = new StringContent("4");

           var resposne = new CheckWebRepositoryResponse().CheckWebResult(new HttpResponseMessage { StatusCode = HttpStatusCode.OK, Content = content });

            Assert.True(resposne.StatusCode == 200);
        }

        [Test]
        public void TestResponseReturnsBadReauest()
        {
            HttpContent content = new StringContent("4");

            var resposne = new CheckWebRepositoryResponse().CheckWebResult(new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest, Content = content });

            Assert.True(resposne.StatusCode == 400);
        }

        [Test]
        public void TestResponseReturnsNotFound()
        {
            HttpContent content = new StringContent("4");

            var resposne = new CheckWebRepositoryResponse().CheckWebResult(new HttpResponseMessage { StatusCode = HttpStatusCode.NotFound, Content = content });

            Assert.True(resposne.StatusCode == 400);
        }
    }
}