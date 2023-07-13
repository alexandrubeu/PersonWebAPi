using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Persistence;

public class Context : DbContext
{
    public DbSet<EPerson> Persons { get; set; }

    public DbSet<EProfile> Profiles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL("server=localhost;database=persons;user=root;password=epixcms");
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var personModelBuilder = modelBuilder.Entity<EPerson>();
        personModelBuilder.Property(x => x.Email).HasMaxLength(255);

        personModelBuilder.HasOne(s => s.Profile)
            .WithOne(p => p.Person).HasForeignKey<EPerson>(z => z.ProfileId);

        var profileModelBuilder = modelBuilder.Entity<EProfile>();
        profileModelBuilder.Property(z => z.Company).HasColumnName("Company").HasMaxLength(255);

        base.OnModelCreating(modelBuilder);
    }
}