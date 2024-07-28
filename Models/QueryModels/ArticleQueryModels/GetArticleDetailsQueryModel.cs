using Article_Management_Backend.Models.DTOs.ArticleDTO;
using MediatR;

namespace Article_Management_Backend.Models.QueryModels.ArticleCategoryModels
{
    public class GetArticleDetailsQueryModel : IRequest<ArticleDetailsModel>
    {
        public GetArticleDetailsQueryModel(Guid articleId)
        {
            ArticleId = articleId;
        }
        public Guid ArticleId { get; set; }
    }
}
