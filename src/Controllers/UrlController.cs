using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using src.Services;
using src.Models;

namespace src.Controllers
{
    [Route("")]
    [ApiController]
    public class UrlController : ControllerBase
    {
        private readonly IShortUrlService shortUrlService;
        public UrlController(IShortUrlService shortUrlService)
        {
            this.shortUrlService = shortUrlService;
        }
        [HttpGet("Redirect/{shortUrl}")]
        public RedirectResult Get(string shortUrl)
        {
            string url = shortUrlService.UrlFinder(shortUrl);
            return Redirect(url);
        }
        [HttpPost("urls")]
        public UrlResource post(UrlRequest request)
        {
            UrlResource resource = shortUrlService.GenerateShortUrl(request);
            return resource;
        }
    }
}