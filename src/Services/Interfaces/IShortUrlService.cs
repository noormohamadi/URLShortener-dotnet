using src.Models;
using System.Linq;
using src.Services.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace src.Services
{
    public interface IShortUrlService
    {
        public UrlResource GenerateShortUrl(UrlRequest urlRequest);
        public string UrlFinder(string shortUrl);
    }
}