using Article_Management_Backend.Models.DTOs.ArticleDTO;
using Article_Management_Backend.Models.FilterModels.ArticleFilters;
using MediatR;

namespace Article_Management_Backend.Models.QueryModels.ArticleCategoryModels
{
    public class GetArticleListFiltersQueryModel : IRequest<List<ArticleModel>>
    {
        public GetArticleListFiltersQueryModel(ArticleListFilterModel articleFilters)
        {
            ArticleFilters = articleFilters;
        }
        public ArticleListFilterModel ArticleFilters { get; set; }
        
    }
}
