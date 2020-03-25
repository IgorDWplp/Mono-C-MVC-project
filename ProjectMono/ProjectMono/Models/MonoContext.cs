using Microsoft.EntityFrameworkCore;

namespace ProjectMono
{
    public class MonoContext : DbContext
    {
        //public MonoContext() : base("MyConnection")
        //{
        // //Database.SetInitializer<Model1>(null);
        //  // Database.SetInitializer<MonoContext>(new CreateDatabaseIfNotExists<MonoContext>()); //ako je promjena ili ako nema baze tada je kreiraj 
        //}


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=.;database=mono;trusted_connection=true");
        }

        //  public DbSet<Standard> standards { get; set; }

        // public DbSet<Student> students { get; set; }

      
    }
}