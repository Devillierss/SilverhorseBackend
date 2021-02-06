using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SilverhorseBackend.Config;
using SilverhorseDtos;
using SilverhorseServiceHelpers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace SilverhorseBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private readonly IWebRepository _WebRepository;
        private readonly IOptions<WebRepositoryConfig> _config;
        private readonly ICheckWebRepositoryResponse _checkWebRepositoryResponse;

        public AlbumsController(IWebRepository webRepository, IOptions<WebRepositoryConfig> config, ICheckWebRepositoryResponse checkWebRepositoryResponse)
        {
            _WebRepository = webRepository;
            _config = config;
            _checkWebRepositoryResponse = checkWebRepositoryResponse;
        }

        /// <summary>
        /// Fetches a List of Album Items.
        /// </summary>
        [HttpGet]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/json")]
        public async Task<IEnumerable<Album>> Get()
        {
            var result = await _WebRepository.GetWebRequest<List<Album>>(_config.Value.BaseUri, "Albums");
            return result;
        }


        /// <summary>
        /// Fetches a Album Item.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<Album> Get(int id)
        {
            var result = await _WebRepository.GetWebRequest<Album>(_config.Value.BaseUri, $"Albums/{id}");
            return result;
        }

        /// <summary>
        /// Creates a Album Item.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST 
        ///     {
        ///        "id": 1,
        ///        "userId": 1,
        ///        "title": "Title",
        ///     }
        ///
        /// </remarks>
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/json")]
        public async Task<IActionResult> Create([FromBody] Album Album)
        {
            var result = await _WebRepository.PostWebRequest<Album>(_config.Value.BaseUri, "Albums", Album);

            return _checkWebRepositoryResponse.CheckWebResult(result);
        }

        /// <summary>
        /// Updates a Album Item.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PATCH 
        ///     {
        ///        "id": 1,
        ///        "title": "Title",
        ///     }
        ///
        /// </remarks>
        [HttpPatch("{id}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/json")]
        public async Task<IActionResult> Update(int id, [FromBody] Album Album)
        {
            var result = await _WebRepository.PatchWebRequest<Album>(_config.Value.BaseUri, $"Albums/{id}", Album);
            return _checkWebRepositoryResponse.CheckWebResult(result);
        }

        /// <summary>
        /// Deletes a specific Album Item.
        /// </summary>
        /// <param name="id"></param> 
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _WebRepository.DeleteWebRequest(_config.Value.BaseUri, $"Albums/{id}");
            return _checkWebRepositoryResponse.CheckWebResult(result);
        }
    }
}
