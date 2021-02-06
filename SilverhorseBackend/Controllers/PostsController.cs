using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SilverhorseBackend.Config;
using SilverhorseDtos;
using SilverhorseServiceHelpers.Interfaces;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace SilverhorseBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {

        private readonly IWebRepository _WebRepository;
        private readonly IOptions<WebRepositoryConfig> _config;
        private readonly ICheckWebRepositoryResponse _checkWebRepositoryResponse;


        public PostsController(IWebRepository webRepository, IOptions<WebRepositoryConfig> config, ICheckWebRepositoryResponse checkWebRepositoryResponse)
        {
            _WebRepository = webRepository;
            _config = config;
            _checkWebRepositoryResponse = checkWebRepositoryResponse;
        }

        /// <summary>
        /// Fetches a List of Post Items.
        /// </summary>
        [HttpGet]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/json")]
        public async Task<IEnumerable<Post>> Get()
        {
            var result = await _WebRepository.GetWebRequest<List<Post>>(_config.Value.BaseUri, "posts");
            return result;
        }


        /// <summary>
        /// Fetches a Post Item.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<Post> Get(int id)
        {
            var result = await _WebRepository.GetWebRequest<Post>(_config.Value.BaseUri, $"posts/{id}");
            return result;
        }

        /// <summary>
        /// Creates a Post Item.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST 
        ///     {
        ///        "id": 1,
        ///        "userId": 1,
        ///        "title": "string",
        ///        "body": "string"
        ///     }
        ///
        /// </remarks>
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/json")]
        public async Task<IActionResult> Create([FromBody] Post post)
        {
            var result = await _WebRepository.PostWebRequest<Post>(_config.Value.BaseUri, "posts", post);

            return _checkWebRepositoryResponse.CheckWebResult(result);
        }

        /// <summary>
        /// Updates a Post Item.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PATCH 
        ///     {
        ///        "id": 1,
        ///        "body": "string"
        ///     }
        ///
        /// </remarks>
        [HttpPatch("{id}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/json")]
        public async Task<IActionResult> Update(int id, [FromBody] Post post)
        {
            var result = await _WebRepository.PatchWebRequest<Post>(_config.Value.BaseUri, $"posts/{id}", post);
            return _checkWebRepositoryResponse.CheckWebResult(result);
        }

        /// <summary>
        /// Deletes a specific Item.
        /// </summary>
        /// <param name="id"></param> 
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _WebRepository.DeleteWebRequest(_config.Value.BaseUri, $"posts/{id}");
            return _checkWebRepositoryResponse.CheckWebResult(result);
        }
    }
}
