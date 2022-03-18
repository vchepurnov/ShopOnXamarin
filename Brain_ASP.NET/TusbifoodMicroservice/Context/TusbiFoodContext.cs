using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Identity;

namespace TusbifoodMicroservice.Context
{
    public partial class TusbiFoodContext: IdentityDbContext<AspNetUser>
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

                entity.HasOne(a => a.Order)
                    .WithMany(p => p.Seats)
                    .HasForeignKey(d => d.OrderId);

                entity.HasOne(d => d.Table)
                    .WithMany(p => p.Seats)
                    .HasForeignKey(a => a.TableId);

                entity.HasData(new Seat[]
                {
                    new Seat(){Id = 1, TableId = 1},
                    new Seat(){Id = 2, TableId = 1},
                    new Seat(){Id = 3, TableId = 1},
                    new Seat(){Id = 4, TableId = 1},
                    new Seat(){Id = 5, TableId = 2},
                    new Seat(){Id = 6, TableId = 2},
                    new Seat(){Id = 7, TableId = 2},
                    new Seat(){Id = 8, TableId = 2},
                    new Seat(){Id = 9, TableId = 3},
                    new Seat(){Id = 10, TableId = 3},
                    new Seat(){Id = 11, TableId = 3},
                    new Seat(){Id = 12, TableId = 3},
                    new Seat(){Id = 13, TableId = 4},
                    new Seat(){Id = 14, TableId = 4},
                    new Seat(){Id = 15, TableId = 4},
                    new Seat(){Id = 16, TableId = 4},
                    new Seat(){Id = 17, TableId = 5},
                    new Seat(){Id = 18, TableId = 5},
                    new Seat(){Id = 19, TableId = 5},
                    new Seat(){Id = 21, TableId = 5},
                    new Seat(){Id = 22, TableId = 6},
                    new Seat(){Id = 23, TableId = 6},
                    new Seat(){Id = 24, TableId = 6},
                    new Seat(){Id = 25, TableId = 6},
                    new Seat(){Id = 26, TableId = 7},
                    new Seat(){Id = 27, TableId = 7},
                    new Seat(){Id = 28, TableId = 7},
                    new Seat(){Id = 29, TableId = 7},
                    new Seat(){Id = 31, TableId = 8},
                    new Seat(){Id = 32, TableId = 8},
                    new Seat(){Id = 33, TableId = 8},
                    new Seat(){Id = 34, TableId = 8},
                    new Seat(){Id = 35, TableId = 8},
                    new Seat(){Id = 36, TableId = 8},
                    new Seat(){Id = 37, TableId = 8},
                    new Seat(){Id = 38, TableId = 8}
                });
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

            builder.Entity<Table>(entity =>
            {
                entity.HasData(new Table[]
                {
                    new Table(){Id = 1 },
                    new Table(){Id = 2 },
                    new Table(){Id = 3 },
                    new Table(){Id = 4 },
                    new Table(){Id = 5 },
                    new Table(){Id = 6 },
                    new Table(){Id = 7 },
                    new Table(){Id = 8 }
                });
            });

            base.OnModelCreating(builder);

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          
        }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderProduct> OrderProducts { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductShoppingCart> ProductShoppingCarts { get; set; }
        public virtual DbSet<Table> Table { get; set; }
        public virtual DbSet<Seat> Seats { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<TypeProduct> TypeProducts { get; set; }
        public virtual DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Models.Category> Category { get; set; }
    }
}
