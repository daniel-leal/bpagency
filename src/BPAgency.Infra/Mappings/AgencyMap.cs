using BPAgency.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BPAgency.Infra.Mappings
{
    public class AgencyMap : IEntityTypeConfiguration<Agency>
    {
        public void Configure(EntityTypeBuilder<Agency> builder)
        {
            builder.Property(a => a.Id)
               .HasColumnName("Id");

            builder.Property(a => a.Name)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(a => a.ServiceStartTime)
                .HasColumnType("varchar(5)")
                .HasMaxLength(5)
                .IsRequired();

            builder.Property(a => a.ServiceEndTime)
                .HasColumnType("varchar(5)")
                .HasMaxLength(5)
                .IsRequired();

            builder.Property(a => a.SelfServiceStartTime)
            .HasColumnType("varchar(5)")
            .HasMaxLength(5)
            .IsRequired();

            builder.Property(a => a.SelfServiceEndTime)
                .HasColumnType("varchar(5)")
                .HasMaxLength(5)
                .IsRequired();

            builder.Property(a => a.Latitude)
                .HasColumnType("numeric(14,8)");

            builder.Property(a => a.Longitude)
                .HasColumnType("numeric(14,8)");

            builder.Property(a => a.Phone)
               .HasColumnType("varchar(20)")
               .HasMaxLength(50)
               .IsRequired();

            builder.Property(a => a.Phone2)
               .HasColumnType("varchar(20)")
               .HasMaxLength(20);

            builder.Property(a => a.Phone3)
                .HasColumnType("varchar(20)")
                .HasMaxLength(20);

            builder.Property(a => a.Address)
                .HasColumnType("varchar(150)")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(a => a.Cep)
                .HasColumnType("varchar(10)")
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(a => a.District)
                .HasColumnType("varchar(40)")
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(a => a.City)
                .HasColumnType("varchar(40)")
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(a => a.IsStation)
                .HasColumnType("bit")
                .IsRequired();

            builder.Property(a => a.IsCapital)
                .HasColumnType("bit")
                .IsRequired();
        }
    }
}
