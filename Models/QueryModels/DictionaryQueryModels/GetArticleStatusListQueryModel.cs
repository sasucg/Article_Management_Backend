using Article_Management_Backend.Models.DTOs.DictionaryDTO;
using MediatR;

namespace Article_Management_Backend.Models.QueryModels.ArticleCategoryModels
{
    public class GetArticleStatusListQueryModel : IRequest<List<DictionaryModel>>
    {

    }
}
