using Domovoy.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Domovoy.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
{
    public DbSet<ApartmentHouse> ApartmentHouses { get; set; } = null!;
    public DbSet<HouseEntrance> HouseEntrances { get; set; } = null!;
    public DbSet<Apartment> Apartments { get; set; } = null!;
    public DbSet<ConstructionCompany> ConstructionCompanies { get; set; } = null!;
    public DbSet<ResidentialComplex> ResidentialComplexes { get; set; } = null!;
    public DbSet<InviteCode> InviteCodes { get; set; } = null!;
    
    public DbSet<SmartHomeDevice> SmartHomeDevices { get; set; } = null!;
    public DbSet<SmartHomeDeviceActionLogEntry> SmartHomeDeviceActionLog { get; set; } = null!;

    public DbSet<Chat> Chats { get; set; } = null!;
    public DbSet<Message> Messages { get; set; } = null!;


    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder
            .Entity<ApartmentHouse>()
            .Property(e => e.Address)
            .HasConversion(
                v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<Address>(v));

        builder.Entity<Apartment>()
            .HasOne(p => p.Owner)
            .WithMany(b => b.OwndedApartments);

        builder.Entity<Apartment>()
            .HasMany(p => p.Tenants)
            .WithMany(b => b.Apartments);
        
        builder.Entity<Apartment>()
            .HasMany(p => p.TenantsWhoAddThisToCart)
            .WithMany(b => b.Cart);

        builder.Entity<ApplicationUser>()
            .HasOne(p => p.MainApartment)
            .WithMany(b => b.TenantsWhoMainThis);
    }
}