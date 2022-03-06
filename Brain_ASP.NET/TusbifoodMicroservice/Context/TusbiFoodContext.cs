using Microsoft.EntityFrameworkCore;
using Models;
using Models.Identity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace TusbifoodMicroservice.Context
{
    public partial class TusbiFoodContext: DbContext
    {
        public TusbiFoodContext(DbContextOptions<TusbiFoodContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasAnnotation("Relational:Collation", "Russian_Russia.1251");

            builder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.HasIndex(e => e.UserProfileId, "IX_Order_UserProfileId");

                entity.HasOne(d => d.UserProfile)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserProfileId);
            });

            builder.Entity<OrderProduct>(entity =>
            {
                entity.HasKey(e => new { e.OrdersId, e.ProductsId });

                entity.ToTable("OrderProduct");

                entity.HasIndex(e => e.ProductsId, "IX_OrderProduct_ProductsId");

                entity.HasOne(d => d.Orders)
                    .WithMany(p => p.OrderProducts)
                    .HasForeignKey(d => d.OrdersId);

                entity.HasOne(d => d.Products)
                    .WithMany(p => p.OrderProducts)
                    .HasForeignKey(d => d.ProductsId);
            });

            builder.Entity<OrderSeat>(entity =>
            {
                entity.HasKey(e => new { e.OrdersId, e.SeatsId });

                entity.ToTable("OrderSeat");

                entity.HasIndex(e => e.SeatsId, "IX_OrderSeat_SeatsId");

                entity.HasOne(d => d.Orders)
                    .WithMany(p => p.OrderSeats)
                    .HasForeignKey(d => d.OrdersId);

                entity.HasOne(d => d.Seats)
                    .WithMany(p => p.OrderSeats)
                    .HasForeignKey(d => d.SeatsId);
            });

            builder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.HasIndex(e => e.TypeProductId, "IX_Product_TypeProductId");

                entity.HasOne(d => d.TypeProduct)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.TypeProductId);
            });

            builder.Entity<ProductShoppingCart>(entity =>
            {
                entity.HasKey(e => new { e.ProductsId, e.ShoppingCartsId });

                entity.ToTable("ProductShoppingCart");

                entity.HasIndex(e => e.ShoppingCartsId, "IX_ProductShoppingCart_ShoppingCartsId");

                entity.HasOne(d => d.Products)
                    .WithMany(p => p.ProductShoppingCarts)
                    .HasForeignKey(d => d.ProductsId);

                entity.HasOne(d => d.ShoppingCarts)
                    .WithMany(p => p.ProductShoppingCarts)
                    .HasForeignKey(d => d.ShoppingCartsId);
            });

            builder.Entity<Seat>(entity =>
            {
                entity.ToTable("Seat");

                entity.HasIndex(e => e.ShoppingCartId, "IX_Seat_ShoppingCartId");

                entity.HasOne(d => d.ShoppingCart)
                    .WithMany(p => p.Seats)
                    .HasForeignKey(d => d.ShoppingCartId);
            });

            builder.Entity<TypeProduct>(entity =>
            {
                entity.ToTable("TypeProduct");
                entity.HasData(new TypeProduct[]
                {
                    new TypeProduct(){Id = 1, Name = "Основное блюдо", CategoryId = 1},
                    new TypeProduct(){Id = 2, CategoryId = 1, Name ="Гарнир"},
                    new TypeProduct(){Id = 3, CategoryId = 1, Name ="Добавки к гарниру"},
                    new TypeProduct(){Id = 4, CategoryId = 2, Name ="Холодный напиток"},
                    new TypeProduct(){Id = 5, CategoryId = 2, Name ="Горячий напиток"},
                    new TypeProduct(){Id = 6, CategoryId = 3, Name ="Прочее"}
                });
            });

            builder.Entity<UserProfile>(entity =>
            {
                entity.ToTable("UserProfile");

                entity.HasOne(d => d.ShoppingCart)
                    .WithOne(p => p.UserProfile)
                    .HasForeignKey<ShoppingCart>(a => a.UserProfileId);

                entity.HasOne(d => d.AspNetUser)
                    .WithOne(a => a.UserProfile)
                    .HasForeignKey<UserProfile>(f => f.AspNetUserId);
            });
            builder.Entity<Category>(entity =>
            {
                entity.ToTable("Categories");
                entity.HasData(new Category[]
            {
                new Category(){Id = 1, Name = "Еда"},
                new Category(){Id = 2, Name = "Напитки"},
                new Category(){Id = 3, Name = "Прочее"}
            });

            });
            builder.Entity<TypeProduct>(entity =>
            {
                entity.HasIndex(e => e.CategoryId, "IX_TypeProduct_CaregoryId");

                entity.HasOne(e => e.Category)
                    .WithMany(d => d.TypeProducts)
                    .HasForeignKey(a => a.CategoryId);
            });

            OnModelCreatingPartial(builder);

        }

        partial void OnModelCreatingPartial(ModelBuilder builder);

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Test;Username=postgres;Password=363kYkmJ");
            }
        }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderProduct> OrderProducts { get; set; }
        public virtual DbSet<OrderSeat> OrderSeats { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductShoppingCart> ProductShoppingCarts { get; set; }
        public virtual DbSet<Seat> Seats { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<TypeProduct> TypeProducts { get; set; }
        public virtual DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Models.Category> Category { get; set; }
    }
}
