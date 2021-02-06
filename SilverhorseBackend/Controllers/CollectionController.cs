using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SilverhorseBackend.Config;
using SilverhorseDtos;
using SilverhorseServiceHelpers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SilverhorseBackend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CollectionController : ControllerBase
    {

        private readonly ICollectionAggregator _collectionAggregator;
        private readonly IOptions<WebRepositoryConfig> _config;
        public CollectionController(ICollectionAggregator collectionAggregator, IOptions<WebRepositoryConfig> config)
        {
            _collectionAggregator = collectionAggregator;
            _config = config;
        }

        /// <summary>
        /// Fetches a List of Album, user amd post items.
        /// </summary>
        [HttpGet]
        public async Task<JsonPlaceHolderCollection> Get()
        {
            var col = await _collectionAggregator.FetchAggrgatedCollectionAsync(_config.Value.BaseUri);

            return col;
        }
    }
}
