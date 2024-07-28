using Article_Management_Backend.Models.DTOs.DictionaryDTO;
using Article_Management_Backend.ReadModel.Entities;

namespace Article_Management_Backend.ReadModel.Interfaces.Repositories
{
    public interface IDictionaryRepository
    {
        public Task<List<DictionaryModel>> GetArticleCategories(CancellationToken cancellationToken);
        public Task<List<DictionaryModel>> GetArticleStatuses(CancellationToken cancellationToken);
        public Task<DictionaryModel> GetArticleStatusById(Guid statusId, CancellationToken cancellationToken);
    }
}