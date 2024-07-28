using Article_Management_Backend.Models.DTOs.ArticleDTO;
using Article_Management_Backend.Models.DTOs.DictionaryDTO;
using Article_Management_Backend.Models.FilterModels.ArticleFilters;
using Article_Management_Backend.Models.QueryModels.ArticleCategoryModels;
using Article_Management_Backend.ReadModel.Entities;
using Article_Management_Backend.ReadModel.Interfaces.Repositories;
using MediatR;

namespace Article_Management_Backend.Handlers.ArticleHandlers
{
    public class GetArticleByIdHandler : IRequestHandler<GetArticleDetailsQueryModel, ArticleDetailsModel>
    {
        private readonly IArticleRepository _articleRepository;
        public GetArticleByIdHandler(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }
        public async Task<ArticleDetailsModel> Handle(GetArticleDetailsQueryModel request, CancellationToken cancellationToken)
        {
            Article article = await _articleRepository.GetArticleById(request.ArticleId, cancellationToken);

            if (article == null)
            {
                throw new ArticleNotFoundException("Article not found");

            }

            ArticleDetailsModel articleDetails = new ArticleDetailsModel()
            {
                ArticleId = article.ArticleId,
                Name = article.Name,
                ArticleStatusName = article.ArticleStatus.ArticleStatusName,
                ArticleCategoryName = article.ArticleCategory.ArticleCategoryName,
                ArticleCategoryId = article.ArticleCategoryId,
                ArticleStatusId = article.ArticleStatusId,
                ArticleCode = article.ArticleCode,
                Description = article.Description,
                PublishDate = article.PublishDate
            };
            return articleDetails;

        }
    }
}
