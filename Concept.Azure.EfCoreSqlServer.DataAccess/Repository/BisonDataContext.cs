using Microsoft.EntityFrameworkCore;

namespace Concept.Azure.EfCoreSqlServer.DataAccess.Repository
{
    public class BisonDataContext : DbContext
    {
        public BisonDataContext(DbContextOptions<BisonDataContext> options)
            : base(options)
        {
        }

        public DbSet<Model.Bison> Bison { get; set; } = default!;

        public DbSet<Model.AggressionLevel> AggressionLevel { get; set;} = default!;

        public DbSet<Model.BiomeCategory> BiomeCategory { get; set; } = default!;
    }
}
