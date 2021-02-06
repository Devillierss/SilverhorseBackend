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
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IWebRepository _WebRepository;
        private readonly IOptions<WebRepositoryConfig> _config;


        public UsersController(IWebRepository webRepository, IOptions<WebRepositoryConfig> config)
        {
            _WebRepository = webRepository;
            _config = config;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            var users = await _WebRepository.GetWebRequest<List<User>>(_config.Value.BaseUri, "users");

            return users;
        }
    }
}
