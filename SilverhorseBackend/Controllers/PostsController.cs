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


        [HttpGet]
        public async Task<IEnumerable<Post>> Get()
        {
            var posts = await _WebRepository.GetWebRequest<List<Post>>(_config.Value.BaseUri, "posts");

            return posts;
        }

        [HttpGet("{id}")]
        public async Task<Post> Get(int id)
        {
            var posts = await _WebRepository.GetWebRequest<Post>(_config.Value.BaseUri, $"posts/{id}");

            return posts;
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Create([FromBody] Post post)
        {
            var posts = await _WebRepository.PostWebRequest<Post>(_config.Value.BaseUri, "posts", post);

            return Ok(posts);
        }

        [HttpPatch("{id}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation("Write your summary here")]
        public async Task<IActionResult> Update(int id, [FromBody] Post post)
        {
            var posts = await _WebRepository.PatchWebRequest<Post>(_config.Value.BaseUri, $"posts/{id}", post);

            return Ok(posts);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var delete = await _WebRepository.DeleteWebRequest(_config.Value.BaseUri, $"posts/{id}");
            return _checkWebRepositoryResponse.CheckWebResult(delete);
        }
    }
}
