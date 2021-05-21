using BPAgency.Domain.Entities;
using BPAgency.Infra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace BPAgency.Infra.Contexts
{
    public class BPAgencyContext : DbContext
    {
        public BPAgencyContext(DbContextOptions<BPAgencyContext> options)
            : base(options)
        {
        }

        public DbSet<Agency> Agencies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AgencyMap());

            base.OnModelCreating(modelBuilder);
        }

    }
}