using Microsoft.EntityFrameworkCore;
using restaurant_api.Models;

namespace restaurant_api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<OrderModel> Orders { get; set; }
        public DbSet<OrderProductModel> OrderProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OrderProductModel>()
               .HasKey(op => new { op.OrderId, op.ProductId });

            modelBuilder.Entity<OrderProductModel>()
                .HasOne(op => op.Pedido)
                .WithMany(o => o.Produtos)
                .HasForeignKey(op => op.OrderId);

            modelBuilder.Entity<OrderProductModel>()
                .HasOne(op => op.Produto)
                .WithMany(p => p.Pedidos)
                .HasForeignKey(op => op.ProductId);
        }
    }
}
