
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1.Entities
{
    public class ApplicationContext: DbContext
    {
        public DbSet<Animal> Animals { get; set; }
        
        private string _connectionString = "server=localhost; database=sys; user=root; password=newpassword";


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySql(
                _connectionString,
                ServerVersion.AutoDetect(_connectionString));
        }
    }
}