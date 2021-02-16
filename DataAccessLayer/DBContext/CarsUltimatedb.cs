using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.DBContext
{
    public class CarsUltimatedb : DbContext
    {
        public CarsUltimatedb(DbContextOptions<CarsUltimatedb> options) : base(options) { }

        private readonly string connection;
        public CarsUltimatedb(string connectionString)
        {
            connection = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connection);
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<CarClass> CarClasses { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
