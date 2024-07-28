using Article_Management_Backend.Models.DTOs.DictionaryDTO;
using Article_Management_Backend.Models.QueryModels.ArticleCategoryModels;
using Article_Management_Backend.ReadModel.Entities;
using Article_Management_Backend.ReadModel.Interfaces.Repositories;
using MediatR;

namespace Article_Management_Backend.Handlers.CategoryHandlers
{
    public class GetArticleCategoryListHandler : IRequestHandler<GetArticleCategoryListQueryModel, List<DictionaryModel>>
    {
        private readonly IDictionaryRepository _dictionaryRepository;
        public GetArticleCategoryListHandler(IDictionaryRepository dictionaryRepository)
        {
            _dictionaryRepository = dictionaryRepository;
        }
        public async Task<List<DictionaryModel>> Handle(GetArticleCategoryListQueryModel request, CancellationToken cancellationToken)
        {

            List<DictionaryModel> categories = await _dictionaryRepository.GetArticleCategories(cancellationToken);
            return categories;
        }
    }
}
