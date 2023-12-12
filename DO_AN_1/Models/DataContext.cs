using DO_AN_1.Areas.Admin.Models;
using Microsoft.EntityFrameworkCore;
using DO_AN_1.Models;

namespace DO_AN_1.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Categori> Categories { get; set; }
        public DbSet<Posts> Posts { get; set; }
        public DbSet<products> products { get; set; }
        public DbSet<AdminMenu> AdminMenus { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<RecentPost> recentPosts { get; set; }
        public DbSet<Contact> contacts { get; set; }
        public DbSet<Collection> collections { get; set; }
        public DbSet<Discount> discounts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<view_Cart_Product> CartProducts { get; set; }
        public DbSet<AdminUser> AdminUsers { get; set; }
    }
}
