using EasySystems.Bookings.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EasySystems.Bookings.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Business> Businesses => Set<Business>();
    public DbSet<BusinessUser> BusinessUsers => Set<BusinessUser>();
    public DbSet<Service> Services => Set<Service>();
    public DbSet<StaffMember> StaffMembers => Set<StaffMember>();
    public DbSet<Booking> Bookings => Set<Booking>();
    public DbSet<EmailOutbox> EmailOutbox => Set<EmailOutbox>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Business>()
            .HasIndex(b => b.Slug)
            .IsUnique();

        builder.Entity<BusinessUser>()
            .HasIndex(bu => new { bu.BusinessId, bu.UserId })
            .IsUnique();

        builder.Entity<BusinessUser>()
            .HasOne(bu => bu.Business)
            .WithMany(b => b.Users)
            .HasForeignKey(bu => bu.BusinessId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<BusinessUser>()
            .HasOne(bu => bu.User)
            .WithMany(u => u.Businesses)
            .HasForeignKey(bu => bu.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Service>()
            .HasIndex(s => new { s.BusinessId, s.Name });

        builder.Entity<Service>()
            .Property(s => s.Price)
            .HasPrecision(18, 2);

        builder.Entity<Service>()
            .HasOne(s => s.Business)
            .WithMany(b => b.Services)
            .HasForeignKey(s => s.BusinessId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<StaffMember>()
            .HasIndex(s => new { s.BusinessId, s.FullName });

        builder.Entity<StaffMember>()
            .HasOne(s => s.Business)
            .WithMany(b => b.StaffMembers)
            .HasForeignKey(s => s.BusinessId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Booking>()
            .Property(b => b.PaidAmount)
            .HasPrecision(18, 2);

        builder.Entity<Booking>()
            .HasIndex(b => new { b.BusinessId, b.StartTime });

        builder.Entity<Booking>()
            .HasIndex(b => new { b.StaffMemberId, b.StartTime, b.EndTime });

        builder.Entity<Booking>()
            .HasOne(b => b.Business)
            .WithMany(b => b.Bookings)
            .HasForeignKey(b => b.BusinessId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Booking>()
            .HasOne(b => b.Service)
            .WithMany(s => s.Bookings)
            .HasForeignKey(b => b.ServiceId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Booking>()
            .HasOne(b => b.StaffMember)
            .WithMany(s => s.Bookings)
            .HasForeignKey(b => b.StaffMemberId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}