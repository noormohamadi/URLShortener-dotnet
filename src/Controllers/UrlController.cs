using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using src.Services;
using src.Models;
using System.Text.RegularExpressions;
using System.Web;

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
        public IActionResult Get(string shortUrl)
        {
            if (shortUrl.Length != 8)
            {
                return BadRequest();
            }
            else
            {
                string url = shortUrlService.UrlFinder(shortUrl);
                if (url != null)
                {
                    return Redirect(HttpUtility.UrlPathEncode(url));
                }
                else
                {
                    return NotFound();
                }
            }
        }
        [HttpPost("urls")]
        public IActionResult post([FromBody]UrlRequest request)
        {
            if (!new Regex(@"((\w)+\:\/\/)").IsMatch(request.Url))
            {
                request.Url = "http://" + request.Url;
            }
            UrlResource resource = shortUrlService.GenerateShortUrl(request);
            if (resource == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(resource);
            }
        }
    }
}