using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApp.Data.Entities;

namespace WebApp.Data.ContextConfigurations;

public class OrganisationContextConfiguration : IEntityTypeConfiguration<Organisation>
{
    public void Configure(EntityTypeBuilder<Organisation> builder)
    {
        builder
            .HasMany(t => t.Employees)
            .WithOne(t => t.Organisation)
            .HasForeignKey(t => t.OrganisationNumber);
        
        builder
            .HasIndex(t => t.OrganisationNumber)
            .IsUnique();
    }
}