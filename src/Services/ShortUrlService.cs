using src.Models;
using System.Linq;
using src.Services.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace src.Services
{
    public class ShortUrlService
    {
        private readonly AppDbContext dbContext;
        public ShortUrlService(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public UrlResource GenerateShortUrl(UrlRequest urlRequest)
        {
            string shortUrl;
            Task<bool> check;
            do
            {
                shortUrl = RandomStringGenerator.GeneratRandomString(8);
                check = dbContext.UrlResources.AnyAsync(foo => foo.ShortenUrl == shortUrl);
                check.Wait();
            } while(check.Result);
            return new UrlResource{
                ShortenUrl = shortUrl,
                Url = urlRequest.Url
            };
        }
    }
}