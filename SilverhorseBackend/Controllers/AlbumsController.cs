﻿using Microsoft.AspNetCore.Http;
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
    public class AlbumsController : ControllerBase
    {
        private readonly IWebRepository _WebRepository;
        private readonly IOptions<WebRepositoryConfig> _config;

        public AlbumsController(IWebRepository webRepository, IOptions<WebRepositoryConfig> config)
        {
            _WebRepository = webRepository;
            _config = config;
        }

        // GET: api/<AlbumController>
        [HttpGet]
        public async Task<IEnumerable<Album>> Get()
        {
            var posts = await _WebRepository.GetWebRequest<List<Album>>(_config.Value.BaseUri, "albums");
            return posts;
        }
    }
}
