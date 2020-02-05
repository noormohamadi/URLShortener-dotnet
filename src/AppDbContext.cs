using Microsoft.EntityFrameworkCore;
using UrlShortener.Models;

namespace src
{
    public class AppDbContext : DbContext
    {
        public DbSet<UrlResource> UrlResources { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UrlResource>().ToTable("url");
            builder.Entity<UrlResource>().HasKey(url => url.ShortenUrl);
            builder.Entity<UrlResource>().HasIndex(url => url.ShortenUrl).IsUnique();
            builder.Entity<UrlResource>().Property(url => url.ShortenUrl).IsRequired();
            builder.Entity<UrlResource>().Property(url => url.Url).IsRequired();
        }

    }
}