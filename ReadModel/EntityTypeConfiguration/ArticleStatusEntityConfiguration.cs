using Article_Management_Backend.ReadModel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Article_Management_Backend.Entities.EntityTypeConfiguration
{
    public class ArticleStatusEntityConfiguration : IEntityTypeConfiguration<ArticleStatus>
    {
        public void Configure(EntityTypeBuilder<ArticleStatus> entity)
        {
            entity.ToTable(nameof(ArticleStatus));
        }
    }
}
