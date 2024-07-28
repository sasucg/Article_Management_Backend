using Article_Management_Backend.Entities.EntityTypeConfiguration;
using Article_Management_Backend.ReadModel.Entities;
using Microsoft.EntityFrameworkCore;

namespace Article_Management_Backend.DataContext
{
    public class ArticleDbContext : DbContext
    {
        public ArticleDbContext(DbContextOptions<ArticleDbContext> options)
        : base(options)
        {
        }

        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<ArticleCategory> ArticleCategories { get; set; }
        public virtual DbSet<ArticleStatus> ArticleStatuses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArticleCategoryEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ArticleEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ArticleStatusEntityConfiguration());
        }
    }
}
