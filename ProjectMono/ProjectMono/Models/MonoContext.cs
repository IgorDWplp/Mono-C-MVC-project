using Microsoft.EntityFrameworkCore;


namespace ProjectMono
{
    public class MonoContext : DbContext
    {
        #region old code for MVC
        //public MonoContext() : base("MyConnection")
        //{
        // //Database.SetInitializer<Model1>(null);
        //  // Database.SetInitializer<MonoContext>(new CreateDatabaseIfNotExists<MonoContext>()); //ako je promjena ili ako nema baze tada je kreiraj 
        //}
        #endregion
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"server=.;database=mono;trusted_connection=true");
        //}
       // public MonoContext() { }

       //  public MonoContext(DbContextOptions<MonoContext> options) : base(options) { }

        // public DbSet<VehicleMake> vehicleMakes { get; set; }
       //  public DbSet<VehicleModel> vehicleModels { get; set; }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<VehicleMake>().HasData(new VehicleMake
        //    {
        //        Id = 1,
        //        Name = "VW"

        //    });
        //    //new VehicleModel
        //    //{
        //    //    Id = 1,
        //    //    Name = "Polo",
        //    //    Abrv = "Po"
        //    //});
        //}

    }
}