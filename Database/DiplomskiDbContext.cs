using DiplomskiBackend.Model;
using Microsoft.EntityFrameworkCore;

namespace DiplomskiBackend.Database
{
    public class DiplomskiDbContext : DbContext
    {
        public DiplomskiDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        public DbSet<Rad> Rad { get; set; }
        public DbSet<Izdanje> Izdanje { get; set; }
        public DbSet<Editor> Editor { get; set; }

        public DbSet<TehnickiSekretar> TehnickiSekretar { get; set; }

        public DbSet<TehnickiUrednik> TehnickiUrednik { get; set; }

        public DbSet<TehnickiSaradnik> TehnickiSaradnik {  get; set; }
        public DbSet<Lektor> Lektor { get; set; }

    }
}
