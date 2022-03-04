using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models.Identity;
using Models;

namespace Identity_Server.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    }
}
