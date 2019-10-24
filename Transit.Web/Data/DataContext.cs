using Microsoft.EntityFrameworkCore;
using Transit.Web.Data.Entities;
using Transit.Web.Models.Data.Entities;

namespace Transit.Web.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Owner> Owners { get; set; }

        public DbSet<Agent> Agents { get; set; }

        public DbSet<License> Licenses { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<VehicleImage> VehicleImages { get; set; }

    }
}
