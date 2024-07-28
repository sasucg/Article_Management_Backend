using Article_Management_Backend.Models.FilterModels.ArticleFilters;
using Article_Management_Backend.Models.DTOs.ArticleDTO;
using Article_Management_Backend.ReadModel.Entities;

namespace Article_Management_Backend.ReadModel.Interfaces.Repositories
{
    public interface IArticleRepository
    {
        public Task<List<ArticleModel>> GetArticlesByFilters(ArticleListFilterModel filters, CancellationToken cancellationToken);
        public Task<Article> GetArticleById(Guid articleId, CancellationToken cancellationToken);
        public Task<bool> CheckArticleByCode(string articleCode, CancellationToken cancellationToken);
        public Task SaveArticle(Article article, CancellationToken cancellationToken);
        public Task UpdateArticle(Article article, CancellationToken cancellationToken);
        public Task DeleteArticle(Guid ArticleId, CancellationToken cancellationToken);
    }
}