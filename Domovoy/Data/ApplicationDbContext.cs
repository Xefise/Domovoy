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

    public DbSet<Service> Services { get; set; } = null!;
    public DbSet<PermanentService> PermanentServices { get; set; } = null!;
    public DbSet<ServiceApartment> ServiceApartments { get; set; } = null!;
    public DbSet<ServiceUser> ServiceUsers { get; set; } = null!;

    public DbSet<Informer> Informers { get; set; } = null!;
    public DbSet<InformMeter> InformMeter { get; set; } = null!;
    public DbSet<EventInformer> EventInformer { get; set; } = null!;
    public DbSet<ActiveSession> ActiveSession { get; set; } = null!;

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

        builder.Entity<EventInformer>()
            .HasOne(p => p.Informer)
            .WithOne(p => p.EventInformer);

        //#region Service
        builder.Entity<Service>()
            .HasOne(p => p.PermanentService)
            .WithOne(p => p.Service)
            .HasForeignKey<PermanentService>(p => p.ServiceId);
        builder.Entity<Service>()
            .HasOne(p => p.ServiceUser)
            .WithOne(p => p.Service)
            .HasForeignKey<ServiceUser>(p => p.ServiceId);
        builder.Entity<Service>()
            .HasOne(p => p.ServiceApartment)
            .WithOne(p => p.Service)
            .HasForeignKey<ServiceApartment>(p => p.ServiceId);
        builder.Entity<ServicePaymentInvoice>()
            .HasOne(p => p.Service)
            .WithMany(p => p.ServicePaymentInvoices);
        //#endregion
    }
}