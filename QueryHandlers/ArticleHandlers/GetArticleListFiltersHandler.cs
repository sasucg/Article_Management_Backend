using Article_Management_Backend.Models.DTOs.ArticleDTO;
using Article_Management_Backend.Models.DTOs.DictionaryDTO;
using Article_Management_Backend.Models.FilterModels.ArticleFilters;
using Article_Management_Backend.Models.QueryModels.ArticleCategoryModels;
using Article_Management_Backend.ReadModel.Entities;
using Article_Management_Backend.ReadModel.Interfaces.Repositories;
using MediatR;

namespace Article_Management_Backend.Handlers.ArticleHandlers
{
    public class GetArticleListFiltersHandler : IRequestHandler<GetArticleListFiltersQueryModel, List<ArticleModel>>
    {
        private readonly IArticleRepository _articleRepository;
        public GetArticleListFiltersHandler(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }
        public async Task<List<ArticleModel>> Handle(GetArticleListFiltersQueryModel request, CancellationToken cancellationToken)
        {

            List<ArticleModel> articles = await _articleRepository.GetArticlesByFilters(request.ArticleFilters, cancellationToken);
            return articles;
        }
    }
}
