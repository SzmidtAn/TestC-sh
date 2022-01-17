using Microsoft.EntityFrameworkCore;

// dotnet ef migrations add XXX



namespace ConsoleApp1.Entities
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Animal> Animals { get; set; }
        public DbSet<AnimalType> AnimalType { get; set; }

        public ApplicationContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnimalType>().HasData(
                new AnimalType
                {
                    ID=1,
                    Name="Dog",
                },
                new AnimalType
                {
                    ID = 2,
                    Name = "Ostrich",
                },
                new AnimalType
                {
                    ID = 3,
                    Name = "Spider",
                });

            modelBuilder.Entity<Animal>().HasData(
                new Animal
                {
                    Id = 1,
                    Name = "Adam",
                    AnimalTypeID = 1,
                },
                new Animal
                {
                    Id = 2,
                    Name = "Benke",
                    AnimalTypeID = 2,
                },
                new Animal
                {
                    Id = 3,
                    Name = "Camilla",
                    AnimalTypeID = 3,
                },
                new Animal
                {
                    Id = 4,
                    Name = "Daniela",
                    AnimalTypeID = 3,
                });
        }
    }
}