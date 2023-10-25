using Microsoft.EntityFrameworkCore;
using StoreApi.Domain.Orders;

namespace StoreApi.Infrastructure.Persistence;

public class OrderDbContext : DbContext
{
    public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
    {
    }

    public DbSet<Domain.Orders.Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<OrderProduct> OrderProducts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Domain.Orders.Order>()
            .Property(o => o.TotalAmount)
            .HasColumnType("decimal(18, 2)"); // Define la precisión y escala adecuadas

        modelBuilder.Entity<Product>()
            .Property(p => p.Price)
            .HasColumnType("decimal(18, 2)");
        modelBuilder.Ignore<Domain.Customers.Customer>();
        //haz la relacion con customer
        
    }
}