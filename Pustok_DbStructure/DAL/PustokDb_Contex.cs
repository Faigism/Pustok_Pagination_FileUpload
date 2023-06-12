using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Pustok_DbStructure.Entities;

namespace Pustok_DbStructure.DAL
{
    public class PustokDb_Contex:DbContext
    {
        public PustokDb_Contex(DbContextOptions<PustokDb_Contex> options):base(options) { }
        
        public DbSet<Slider> Slider { get; set; }
        public DbSet<Feature> Feature { get; set; }
        public DbSet<Products> Product { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Slider>(x =>
            {
                x.Property(i => i.ImageName).HasMaxLength(100).IsRequired();
                x.Property(n1 => n1.Name1).HasMaxLength(60).IsRequired(false);
                x.Property(n2 => n2.Name2).HasMaxLength(60).IsRequired(false);
                x.Property(txt => txt.Txt).HasMaxLength(100).IsRequired(false);
                x.Property(bt => bt.Button).HasMaxLength(50).IsRequired(false);
                x.Property(si => si.SliderId).HasColumnType("bit").IsRequired();
            });
            modelBuilder.Entity<Feature>(x =>
            {
                x.Property(i => i.Icon).HasMaxLength(50);
                x.Property(t => t.Title1).HasMaxLength(60);
                x.Property(t2 => t2.Title2).HasMaxLength(60);
            });
            modelBuilder.Entity<Products>(x =>
            {
                x.Property(i => i.ImageName).HasMaxLength(100);
                x.Property(t => t.Title).HasMaxLength(60);
                x.Property(d => d.Description).HasMaxLength(60);
                x.Property(p => p.Price).HasColumnType("money");
            });
            modelBuilder.Entity<Books>(x =>
            {
                x.Property(n => n.Name).HasMaxLength(60);
                x.Property(st => st.StockStatus).HasColumnType("bit");
                x.Property(sp => sp.SalePrice).HasColumnType("money");
                x.Property(n => n.CostPrice).HasColumnType("money");
                x.Property(n => n.DiscountPercent).HasColumnType("float");
                x.Property(n => n.Description).IsRequired(false);
                x.Property(n => n.Name).HasMaxLength(60);
            });
            modelBuilder.Entity<Authors>(x =>
            {
                x.Property(n => n.FullName).HasMaxLength(60);
            });
            modelBuilder.Entity<Genres>(x =>
            {
                x.Property(n => n.Name).HasMaxLength(60);
            });
            modelBuilder.Entity<Tags>(x =>
            {
                x.Property(n => n.Name).HasMaxLength(100).IsRequired(false);
            });
            modelBuilder.Entity<BookImages>(x =>
            {
                x.Property(n => n.ImageName).HasMaxLength(100);
                x.Property(n => n.PosterStatus).HasColumnType("bit");
            });
            modelBuilder.Entity<Orders>(x =>
            {
                x.Property(n => n.FullName).HasMaxLength(60).IsRequired();
                x.Property(n => n.Email).HasMaxLength(60).IsRequired();
                x.Property(n => n.Phone).HasMaxLength(60).IsRequired();
                x.Property(n => n.Address).HasMaxLength(100).IsRequired();
                x.Property(n => n.CreatedAt).HasColumnType("datetime2").IsRequired();
            });
            modelBuilder.Entity<OrderItems>(x =>
            {
                x.Property(n => n.UnitSalePrice).HasColumnType("money").IsRequired();
                x.Property(n => n.UnitCostPrice).HasColumnType("money").IsRequired();
                x.Property(n => n.UnitDiscountPercent).HasColumnType("float").IsRequired();
            });
            modelBuilder.Entity<OrderItems>().HasKey(x => new { x.OrderId, x.BookId });
            modelBuilder.Entity<BookTags>().HasKey(x => new { x.BookId, x.TagId });
        }
    }
}
