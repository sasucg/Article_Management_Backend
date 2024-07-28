using Article_Management_Backend.ReadModel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Article_Management_Backend.Entities.EntityTypeConfiguration
{
    public class ArticleCategoryEntityConfiguration : IEntityTypeConfiguration<ArticleCategory>
    {
        public void Configure(EntityTypeBuilder<ArticleCategory> entity)
        {
            entity.ToTable(nameof(ArticleCategory));
        }
    }
}
