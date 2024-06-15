using FoodDelivery.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodDelivery
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }

        //Models
        public DbSet<Users> Users { get; set; }
        public DbSet<Couriers> Couriers { get; set; }
        public DbSet<Items> Items { get; set; }
        public DbSet<Menus> Menus { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Payments> Payments { get; set; }
        public DbSet<Restaurants> Restaurants { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure many-to-many relationship ItemsOrders
            modelBuilder.Entity<Orders>()
                .HasMany(o => o.Items)
                .WithMany(i => i.Orders)
                .UsingEntity<Dictionary<string, object>>(
                    "OrderItems",
                    j => j
                        .HasOne<Items>()
                        .WithMany()
                        .HasForeignKey("ItemsId")
                        .OnDelete(DeleteBehavior.Cascade),
                    j => j
                        .HasOne<Orders>()
                        .WithMany()
                        .HasForeignKey("OrdersId")
                        .OnDelete(DeleteBehavior.Cascade));

            base.OnModelCreating(modelBuilder);
        }
    }
}
