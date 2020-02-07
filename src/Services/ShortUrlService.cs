using src.Models;
using System.Linq;
using src.Services.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;

namespace src.Services
{
    public class ShortUrlService : IShortUrlService
    {
        private readonly AppDbContext dbContext;
        public ShortUrlService(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public UrlResource GenerateShortUrl(UrlRequest urlRequest)
        {
            if(Validator.UrlValidator(urlRequest.Url))
            {
                string shortUrl;
                Task<bool> check;
                do
                {
                    shortUrl = RandomStringGenerator.GeneratRandomString(8);
                    check = dbContext.UrlResources.AnyAsync(foo => foo.ShortenUrl == shortUrl);
                    check.Wait();
                } while(check.Result);
                UrlResource resource = new UrlResource
                {
                    ShortenUrl = shortUrl,
                    Url = urlRequest.Url
                };
                dbContext.UrlResources.Add(resource);
                dbContext.SaveChanges();
                return resource;
            }
            else
            {
                return null;
            }
        }
        public string UrlFinder(string shortUrl)
        {
            string url = null;
            bool check = dbContext.UrlResources.Any(foo => foo.ShortenUrl == shortUrl);
            if (check)
            {
                UrlResource find = dbContext.UrlResources.Where(resource => resource.ShortenUrl == shortUrl).Single();
                url = find.Url;
            }
            return url;
        }
    }
}