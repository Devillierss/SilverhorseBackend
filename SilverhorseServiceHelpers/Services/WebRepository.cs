using SilverhorseServiceHelpers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SilverhorseServiceHelpers.Services
{
    public class WebRepository : IWebRepository
    {

        private static readonly HttpClient _client = new HttpClient();
        private readonly IClassSerializer _classSerializer;

        public WebRepository(IClassSerializer classSerializer)
        {
            _classSerializer = classSerializer;
        }

        public async Task<T> GetWebRequest<T>(string baseUri, string route)
        {
            var result = await Get($"{baseUri}{route}");
            return _classSerializer.Deserialize<T>(result);
        }

        public async Task<HttpResponseMessage> PostWebRequest<T>(string baseUri, string route, T request)
        {
            var jsonString = _classSerializer.Serialize<T>(request);
            return await Post($"{baseUri}{route}", jsonString);
        }

        public async Task<HttpResponseMessage> PatchWebRequest<T>(string baseUri, string route, T request)
        {
            var jsonString = _classSerializer.Serialize<T>(request);
            return await Patch($"{baseUri}{route}", jsonString);
        }

        public async Task<HttpResponseMessage> DeleteWebRequest(string baseUri, string route)
        {
            return await Delete($"{baseUri}{route}");
        }


        private async Task<string> Get(string uri)
        {
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Add("User-Agent", "Jsonplaceholder Fetcher");
            var stringTask = _client.GetStringAsync(uri);

            return await stringTask;
        }

        private async Task<HttpResponseMessage> Post(string uri, string jsonString)
        {
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Add("User-Agent", "Jsonplaceholder Fetcher");
            return await _client.PostAsync(uri, new StringContent(jsonString, Encoding.UTF8, "application/json"));
        }

        private async Task<HttpResponseMessage> Patch(string uri, string jsonString)
        {
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Add("User-Agent", "Jsonplaceholder Fetcher");
            return await _client.PatchAsync(uri, new StringContent(jsonString, Encoding.UTF8, "application/json"));
        }

        private async Task<HttpResponseMessage> Delete(string uri)
        {
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Add("User-Agent", "Jsonplaceholder Fetcher");
            return await _client.DeleteAsync(uri);
        }
    }
}
