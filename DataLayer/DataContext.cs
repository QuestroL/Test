using DataLayer.Entity;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class DataContext : DbContext
    {
        private string _connectionString;

        public DataContext() 
            : this("server=localhost;user=root;password=14101992;port=3306;database=test")
        {

        }

        public DataContext(string connectionString)
        {
           _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(_connectionString, ServerVersion.AutoDetect(_connectionString), ob => ob.MigrationsAssembly(typeof(DataContext).Assembly.GetName().Name));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<UserComment> Comments { get; set; } 

    }
}
