using Microsoft.EntityFrameworkCore;

namespace Concept.Azure.EfCoreSqlServer.DataAccess.DataContext
{
    public class SafariDataContext : DbContext
    {
        public SafariDataContext(DbContextOptions<SafariDataContext> options)
            : base(options)
        {
        }

        public DbSet<Model.Bison> Bison { get; set; } = default!;

        public DbSet<Model.AggressionLevel> AggressionLevel { get; set; } = default!;

        public DbSet<Model.BiomeCategory> BiomeCategory { get; set; } = default!;
    }
}
