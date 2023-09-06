using Microsoft.EntityFrameworkCore;
using WebApp.Data.ContextConfigurations;
using WebApp.Data.Entities;
using WebApp.Migrations;

namespace WebApp.Data;

public class ApplicationDbContext : DbContext
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public ApplicationDbContext(DbContextOptions options)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        SeedData.Initialize(builder);
        builder.ApplyConfiguration(new OrganisationContextConfiguration());
        builder.ApplyConfiguration(new EmployeeContextConfiguration());
        base.OnModelCreating(builder);
    }
    
    public DbSet<Organisation> Organisations { get; set; }
    public DbSet<Employee> Employees { get; set; }
}