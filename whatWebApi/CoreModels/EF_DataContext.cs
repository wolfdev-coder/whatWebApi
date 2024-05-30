using Microsoft.EntityFrameworkCore;
using whatWebApi.CoreModels;

namespace whatWebApi.Models
{
    public class EF_DataContext: DbContext
    {
        public EF_DataContext(DbContextOptions<EF_DataContext> options) : base(options) { }
        public DbSet<Authors> Authors { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<Genres> Genres { get; set; }
        /*public void OnModelCreating (ModelBuilder modelBuilder) 
        {
            modelBuilder.UseSerialColumns();
        }*/
    }
}
