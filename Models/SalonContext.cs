using Microsoft.EntityFrameworkCore;

namespace HairSalon.Models
{
    public class SalonContext : DbContext
    {
        public virtual DbSet<Stylists> Stylists {get; set;}

        public SalonContext(DbContextOptions options) : base(options) {}
    }
}