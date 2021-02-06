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
    public class UsersController : ControllerBase
    {
        private readonly IWebRepository _WebRepository;
        private readonly IOptions<WebRepositoryConfig> _config;
        private readonly ICheckWebRepositoryResponse _checkWebRepositoryResponse;


        public UsersController(IWebRepository webRepository, IOptions<WebRepositoryConfig> config, ICheckWebRepositoryResponse checkWebRepositoryResponse)
        {
            _WebRepository = webRepository;
            _config = config;
            _checkWebRepositoryResponse = checkWebRepositoryResponse;
        }

        /// <summary>
        /// Fetches a List of User Items.
        /// </summary>
        [HttpGet]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/json")]
        public async Task<IEnumerable<User>> Get()
        {
            var result = await _WebRepository.GetWebRequest<List<User>>(_config.Value.BaseUri, "Users");
            return result;
        }


        /// <summary>
        /// Fetches a User Item.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<User> Get(int id)
        {
            var result = await _WebRepository.GetWebRequest<User>(_config.Value.BaseUri, $"Users/{id}");
            return result;
        }

        /// <summary>
        /// Creates a User Item.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST 
        ///     {
        ///            "id": 1,
        ///            "name": "name",
        ///            "userName": "userName",
        ///            "email": "email",
        ///            "address": {
        ///                "street": "street",
        ///                "suite": "suite",
        ///                "city": "city",
        ///                "zipcode": "zipcode",
        ///                "geo": {
        ///                        "lat": "-37.3159",
        ///                        "lng": "37.3159"
        ///                        }
        ///            },
        ///            "phone": "1-770-736-8031 x56442",
        ///            "website": "website",
        ///            "company": {
        ///                        "name": "name",
        ///                        "catchPhrase": "catchPhrase",
        ///                        "bs": "bs"
        ///                        }
        ///        }
        ///
        /// </remarks>
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/json")]
        public async Task<IActionResult> Create([FromBody] User User)
        {
            var result = await _WebRepository.PostWebRequest<User>(_config.Value.BaseUri, "Users", User);

            return _checkWebRepositoryResponse.CheckWebResult(result);
        }

        /// <summary>
        /// Updates a User Item.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PATCH 
        ///     {
        ///            "id": 1,
        ///            "name": "name",
        ///            "userName": "userName",
        ///            "email": "email",
        ///            "address": {
        ///                "street": "street",
        ///                "suite": "suite",
        ///                "city": "city",
        ///                "zipcode": "zipcode",
        ///                "geo": {
        ///                        "lat": "-37.3159",
        ///                        "lng": "37.3159"
        ///                        }
        ///            },
        ///            "phone": "1-770-736-8031 x56442",
        ///            "website": "website"
        ///        }
        ///
        /// </remarks>
        [HttpPatch("{id}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/json")]
        public async Task<IActionResult> Update(int id, [FromBody] User User)
        {
            var result = await _WebRepository.PatchWebRequest<User>(_config.Value.BaseUri, $"Users/{id}", User);
            return _checkWebRepositoryResponse.CheckWebResult(result);
        }

        /// <summary>
        /// Deletes a specific User Item.
        /// </summary>
        /// <param name="id"></param> 
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _WebRepository.DeleteWebRequest(_config.Value.BaseUri, $"Users/{id}");
            return _checkWebRepositoryResponse.CheckWebResult(result);
        }
    }
}
