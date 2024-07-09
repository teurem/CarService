using digitization.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace digitization.Data;

public class ApplicationDbContext : IdentityDbContext<User, IdentityRole, string>
{
    public DbSet<Point> Points { get; set; }
    public DbSet<Reason> Reasons { get; set; }
    public DbSet<RoadMap> RoadMaps { get; set; }
    public DbSet<Orders> Orders { get; set; }
    public DbSet<OrdersPointStatus> OrdersPointStatuses { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<OrdersPointStatus>()
            .HasKey(a => new {a.OrdersId, a.ExecutorId});

        modelBuilder.Entity<Orders>()
            .HasOne(o => o.Mechanic)
            .WithMany()
            .HasForeignKey(o => o.MechanicId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Orders>()
            .HasOne(o => o.AutoElectrician)
            .WithMany()
            .HasForeignKey(o => o.AutoElectricianId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Orders>()
            .HasOne(o => o.Walker)
            .WithMany()
            .HasForeignKey(o => o.WalkerId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Orders>()
            .HasOne(o => o.Painter)
            .WithMany()
            .HasForeignKey(o => o.PainterId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Orders>()
            .HasOne(o => o.Motorist)
            .WithMany()
            .HasForeignKey(o => o.MotoristId)
            .OnDelete(DeleteBehavior.SetNull);

        var points = new List<Point>();

        points.Add(new Point
        {
            Id = 101,
            Name = "в обработке",
            CreatedAt = DateTime.UtcNow,
        });
        points.Add(new Point
        {
            Id = 102,
            Name = "в процессе",
            CreatedAt = DateTime.UtcNow,
        });
        points.Add(new Point
        {
            Id = 103,
            Name = "завершен",
            CreatedAt = DateTime.UtcNow,
        });

        modelBuilder.Entity<Point>().HasData(points);

        var reasons = new List<Reason>();

        reasons.Add(new Reason
        {
            Id = 1001,
            Name = "принять заказ",
            CreatedAt = DateTime.UtcNow,
        });
        reasons.Add(new Reason
        {
            Id = 1002,
            Name = "добавить запчасти",
            CreatedAt = DateTime.UtcNow,
        });
        reasons.Add(new Reason
        {
            Id = 1003,
            Name = "завершить заказ",
            CreatedAt = DateTime.UtcNow,
        });

        modelBuilder.Entity<Reason>().HasData(reasons);

        var roadMaps = new List<RoadMap>();

        roadMaps.Add(new RoadMap
        {
            Id = 1,
            SourcePointId = 101,
            TargetPointId = 102,
            ReasonId = 1001,
            CreatedAt = DateTime.UtcNow,
        });
        roadMaps.Add(new RoadMap
        {
            Id = 2,
            SourcePointId = 102,
            TargetPointId = 102,
            ReasonId = 1002,
            CreatedAt = DateTime.UtcNow,
        });
        roadMaps.Add(new RoadMap
        {
            Id = 3,
            SourcePointId = 102,
            TargetPointId = 103,
            ReasonId = 1003,
            CreatedAt = DateTime.UtcNow,
        });

        modelBuilder.Entity<RoadMap>().HasData(roadMaps);
    }
}
