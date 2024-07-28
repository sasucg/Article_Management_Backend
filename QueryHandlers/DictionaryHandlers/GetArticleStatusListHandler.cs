
using Article_Management_Backend.Models.DTOs.DictionaryDTO;
using Article_Management_Backend.Models.QueryModels.ArticleCategoryModels;
using Article_Management_Backend.ReadModel.Entities;
using Article_Management_Backend.ReadModel.Interfaces.Repositories;
using MediatR;

namespace Article_Management_Backend.Handlers.CategoryHandlers
{
    public class GetArticleStatusListHandler : IRequestHandler<GetArticleStatusListQueryModel, List<DictionaryModel>>
    {
        private readonly IDictionaryRepository _dictionaryRepository;
        public GetArticleStatusListHandler(IDictionaryRepository dictionaryRepository)
        {
            _dictionaryRepository = dictionaryRepository;
        }
        public async Task<List<DictionaryModel>> Handle(GetArticleStatusListQueryModel request, CancellationToken cancellationToken)
        {

            List<DictionaryModel> statuses = await _dictionaryRepository.GetArticleStatuses(cancellationToken);
            return statuses;
        }
    }
}
