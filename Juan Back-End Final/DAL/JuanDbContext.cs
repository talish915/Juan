using Juan_Back_End_Final.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Juan_Back_End_Final.DAL
{
    public class JuanDbContext : DbContext
    {
        public JuanDbContext(DbContextOptions<JuanDbContext> options): base(options) { }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Social> Socials { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<ProductColorSize> ProductColorSizes { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<ServiceOffer> ServiceOffers { get; set; }
        public DbSet<Slider> Sliders { get; set; }
    }
}
