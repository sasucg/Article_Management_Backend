using Article_Management_Backend.DataContext;
using Article_Management_Backend.Models.DTOs.DictionaryDTO;
using Article_Management_Backend.ReadModel.Entities;
using Article_Management_Backend.ReadModel.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Article_Management_Backend.Repositories
{
    public class DictionaryRepository : IDictionaryRepository
    {
        private readonly ArticleDbContext _context;
        public DictionaryRepository(ArticleDbContext context)
        {
            _context = context;
        }

        public async Task<List<DictionaryModel>> GetArticleCategories(CancellationToken cancellationToken)
        {
            IQueryable<ArticleCategory> categories = _context.ArticleCategories;

            return await categories.Select(category => new DictionaryModel()
            {
                Id = category.ArticleCategoryId,
                Value = category.ArticleCategoryName,
                Code = category.ArticleCategoryCode,

            }).ToListAsync(cancellationToken);
        }
        
        public async Task<List<DictionaryModel>> GetArticleStatuses(CancellationToken cancellationToken)
        {
            IQueryable<ArticleStatus> statuses = _context.ArticleStatuses;

            return await statuses.Select(status => new DictionaryModel()
            {
                Id = status.ArticleStatusId,
                Value = status.ArticleStatusName,
                Code = status.ArticleStatusCode,

            }).ToListAsync(cancellationToken);
        }
        
        public async Task<DictionaryModel> GetArticleStatusById(Guid articleId, CancellationToken cancellationToken)
        {
            ArticleStatus status = await _context.ArticleStatuses
                .Where(x => x.ArticleStatusId == articleId)
                .FirstOrDefaultAsync(cancellationToken);

            return new DictionaryModel()
            {
                Code = status.ArticleStatusCode,
                Id = status.ArticleStatusId,
                Value = status.ArticleStatusName
            };
        }
    }
}
