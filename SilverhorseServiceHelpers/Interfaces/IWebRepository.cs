using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SilverhorseServiceHelpers.Interfaces
{
    public interface IWebRepository
    {
        Task<T> GetWebRequest<T>(string baseUri, string route);
        Task<HttpResponseMessage> PostWebRequest<T>(string baseUri, string route, T request);
        Task<HttpResponseMessage> PatchWebRequest<T>(string baseUri, string route, T request);
        Task<HttpResponseMessage> DeleteWebRequest(string baseUri, string route);
    }
}
