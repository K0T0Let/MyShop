using Microsoft.EntityFrameworkCore;
using MyShop.data.Models;

namespace MyShop.data.DB
{
    public class ShopDBContext : DbContext
    {
        public DbSet<Brand> Brands { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Assembly> Assemblys { get; set; } = null!;
        public DbSet<Color> Colors { get; set; } = null!;
        public DbSet<Property> Properties { get; set; } = null!;
        public DbSet<Image> Images { get; set; } = null!;
        public DbSet<Category_property> Category_property { get; set; } = null!;

        public ShopDBContext(DbContextOptions<ShopDBContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Описание связи многие ко многим с дополнительной таблицей
            modelBuilder.Entity<Assembly>()
                .HasMany(a => a.Properties)
                .WithMany(p => p.Assemblies)
                .UsingEntity<Connection_table>(
                    j => j
                        .HasOne(ct => ct.Property)
                        .WithMany(p => p.Connections)
                        .HasForeignKey(ct => ct.PropertyId),
                    j => j
                        .HasOne(ct => ct.Assembly)
                        .WithMany(a => a.Connections)
                        .HasForeignKey(ct => ct.AssemblyId),
                    j =>
                    {
                        j.Property(ct => ct.Meaning).HasDefaultValue("");
                        j.HasKey(ct => new { ct.AssemblyId, ct.PropertyId });
                        j.ToTable("Connection_table");
                    }
                );

            //Выключает каскадное удаление
            modelBuilder.Entity<Brand>()
                .HasOne(b => b.Image)
                .WithMany(i => i.Brands)
                .HasForeignKey(b => b.ImageId)
                .OnDelete(DeleteBehavior.Restrict);

            /*modelBuilder.Entity<Property>()
                .HasOne(p => p.Category_property)
                .WithMany(cp => cp.Properties)
                .HasForeignKey(p => p.Category_propertyId)
                .OnDelete(DeleteBehavior.Restrict);*/
        }
    }
}
