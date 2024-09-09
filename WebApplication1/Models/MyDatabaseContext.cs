using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class MyDatabaseContext : DbContext
    {
        public MyDatabaseContext(DbContextOptions<MyDatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<Point> Points { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Point>().ToTable("points");
            base.OnModelCreating(modelBuilder);

            // Point tablosu için yapılandırma
            modelBuilder.Entity<Point>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.PointX).IsRequired();
                entity.Property(e => e.PointY).IsRequired();
                entity.Property(e => e.Name).HasMaxLength(100).IsRequired();
            });
        }
    }
}
