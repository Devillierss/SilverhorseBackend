using Microsoft.AspNetCore.Mvc;
using SilverhorseServiceHelpers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace SilverhorseServiceHelpers.Services
{
    public class CheckWebRepositoryResponse : ICheckWebRepositoryResponse
    {
        public ObjectResult CheckWebResult(HttpResponseMessage responseMessage)
        {
            if (responseMessage.IsSuccessStatusCode)
            {
                return new OkObjectResult(responseMessage.ReasonPhrase);
            }
            else
            {
                return new BadRequestObjectResult(responseMessage.ReasonPhrase);
            }
        }
    }
}
