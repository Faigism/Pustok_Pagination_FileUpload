using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Pustok_DbStructure.Entities;

namespace Pustok_DbStructure.DAL
{
    public class PustokDb_Contex:DbContext
    {
        public PustokDb_Contex(DbContextOptions<PustokDb_Contex> options):base(options) { }
        
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<BookImage> BookImages { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<BookTag> BookTags { get; set; }
        public DbSet<Book> Books { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Slider>(x =>
            {
                x.Property(i => i.ImageName).HasMaxLength(100).IsRequired();
                x.Property(n1 => n1.Name1).HasMaxLength(60).IsRequired(false);
                x.Property(n2 => n2.Name2).HasMaxLength(60).IsRequired(false);
                x.Property(txt => txt.Txt).HasMaxLength(100).IsRequired(false);
                x.Property(bt => bt.BtnText).HasMaxLength(50).IsRequired();
                x.Property(bt => bt.BtnUrl).HasMaxLength(50).IsRequired();
            });
            modelBuilder.Entity<Feature>(x =>
            {
                x.Property(i => i.Icon).HasMaxLength(50);
                x.Property(t => t.Title1).HasMaxLength(60);
                x.Property(t2 => t2.Title2).HasMaxLength(60);
            });
            modelBuilder.Entity<Book>(x =>
            {
                x.Property(n => n.Name).HasMaxLength(60);
                x.Property(st => st.StockStatus).HasColumnType("bit");
                x.Property(sp => sp.SalePrice).HasColumnType("money");
                x.Property(n => n.CostPrice).HasColumnType("money");
                x.Property(n => n.DiscountPercent).HasColumnType("decimal(18,2)");
                x.Property(n => n.Description).IsRequired(false);
                x.Property(n => n.Name).HasMaxLength(60);
            });
            modelBuilder.Entity<Author>(x =>
            {
                x.Property(n => n.FullName).HasMaxLength(60);
            });
            modelBuilder.Entity<Genre>(x =>
            {
                x.Property(n => n.Name).HasMaxLength(60);
            });
            modelBuilder.Entity<Tag>(x =>
            {
                x.Property(n => n.Name).HasMaxLength(100).IsRequired(false);
            });
            modelBuilder.Entity<BookImage>(x =>
            {
                x.Property(n => n.ImageName).HasMaxLength(100);
                x.Property(n => n.PosterStatus).HasColumnType("bit");
            });
            modelBuilder.Entity<BookTag>().HasKey(x => new { x.BookId, x.TagId });
        }
    }
}
