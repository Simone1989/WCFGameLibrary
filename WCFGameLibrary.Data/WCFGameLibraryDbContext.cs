using System.Data.Entity;
using WCFGameLibrary.Model;

namespace WCFGameLibrary.Data
{
    public class WCFGameLibraryDbContext : DbContext
    {
        public WCFGameLibraryDbContext():base("WCFGameLibraryDb")
        {
                
        }

        public DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
