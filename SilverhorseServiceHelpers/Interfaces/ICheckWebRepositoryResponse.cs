using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SilverhorseServiceHelpers.Interfaces
{
    public interface ICheckWebRepositoryResponse
    {
        ObjectResult CheckWebResult(HttpResponseMessage responseMessage);
    }
}
