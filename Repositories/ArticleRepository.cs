using Article_Management_Backend.DataContext;
using Article_Management_Backend.ReadModel.Entities;
using Article_Management_Backend.ReadModel.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Article_Management_Backend.Models.FilterModels.ArticleFilters;
using Article_Management_Backend.Models.DTOs.ArticleDTO;

namespace Article_Management_Backend.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly ArticleDbContext _context;
        public ArticleRepository(ArticleDbContext context)
        {
            _context = context;
        }

        public async Task<List<ArticleModel>> GetArticlesByFilters(ArticleListFilterModel filters, CancellationToken cancellationToken)
        {
            IQueryable<Article> articles = _context.Articles
                .Include(x => x.ArticleCategory)
                .Include(x => x.ArticleStatus);

            if(filters.CategoryId != null)
            {
                articles = articles.Where(x => x.ArticleCategoryId == filters.CategoryId);
            }

            if(filters.StatusId != null)
            {
                articles = articles.Where(x => x.ArticleStatusId == filters.StatusId);
            }

            if(filters.StartDate != null)
            {
                articles = articles.Where(x => x.PublishDate > filters.StartDate);
            }

            if(filters.EndDate != null)
            {
                articles = articles.Where(x => x.PublishDate < filters.EndDate);
            }
            
            if(filters.Name != null)
            {
                articles = articles.Where(x => x.Name.Contains(filters.Name));
            }
            
            if(filters.Code != null)
            {
                articles = articles.Where(x => x.ArticleCode == filters.Code);
            }

            return await articles.Select(article => new ArticleModel()
            {
                ArticleId = article.ArticleId,
                ArticleCode = article.ArticleCode,
                Name = article.Name,
                ArticleStatusName = article.ArticleStatus.ArticleStatusName,
                ArticleCategoryName = article.ArticleCategory.ArticleCategoryName,
                PublishDate = article.PublishDate
            }).ToListAsync(cancellationToken);
        }
        
        public async Task<Article> GetArticleById(Guid articleId, CancellationToken cancellationToken)
        {
            return await _context.Articles
                .Include(x => x.ArticleStatus)
                .Include(x => x.ArticleCategory)
                .Where(x => x.ArticleId == articleId)
                .FirstOrDefaultAsync(cancellationToken);
        }
        
        public async Task<bool> CheckArticleByCode(string articleCode, CancellationToken cancellationToken)
        {
            return await _context.Articles
                .Where(x => x.ArticleCode == articleCode)
                .AnyAsync(cancellationToken);
        }
        
        public async Task SaveArticle(Article article, CancellationToken cancellationToken)
        {
            await _context.Articles.AddAsync(article);
            _context.SaveChanges();
        }
        
        public async Task UpdateArticle(Article article, CancellationToken cancellationToken)
        {
            _context.Articles.Update(article);
            _context.SaveChanges();
        }

        public async Task DeleteArticle(Guid articleId, CancellationToken cancellationToken)
        {
            Article article = await _context.Articles.Where(x => x.ArticleId == articleId)
                .FirstOrDefaultAsync(cancellationToken);

            _context.Articles.Remove(article);
            _context.SaveChanges();
        }
    }
}
