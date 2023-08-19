using Microsoft.EntityFrameworkCore;
using publabb1.Server.Data.Model;

namespace publabb1.Server.Data
{
    public class CountryContext : DbContext
    {
        public CountryContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();}
        public DbSet<CountryModel> CountryTable { get; set; }
        public DbSet<CityModel> CityTable { get; set; }

    }
}
