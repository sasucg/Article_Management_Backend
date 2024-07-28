using Article_Management_Backend.ReadModel.Interfaces.Repositories;
using Article_Management_Backend.Commands;
using MediatR;
using Article_Management_Backend.ReadModel.Entities;
namespace Article_Management_Backend.CommandHandlers
{
    public class SaveArticleCommandHandler : IRequestHandler<SaveArticleCommand, SaveArticleResponse>
    {
        private readonly IArticleRepository _articleRepository;

        public SaveArticleCommandHandler(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        // Usually I would use same request & command for insert / update
        // If existing ArticleId => update
        // Else => insert
        // We use different requests to use POST & PUT

        public async Task<SaveArticleResponse> Handle(SaveArticleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                bool checkArticleCode = await _articleRepository.CheckArticleByCode(request.ArticleCode, cancellationToken);

                if (!checkArticleCode)
                {
                    Article article = new Article()
                    {
                        ArticleId = Guid.NewGuid(),
                        ArticleStatusId = request.ArticleStatusId,
                        ArticleCategoryId = request.ArticleCategoryId,
                        Name = request.Name,
                        ArticleCode = request.ArticleCode,
                        CreatedOn = DateTime.UtcNow,
                        CreatedBy = Guid.NewGuid(),
                        Description = request.Description,
                        PublishDate = DateTime.UtcNow
                    };

                    await _articleRepository.SaveArticle(article, cancellationToken);

                    return new SaveArticleResponse
                    {
                        Event = "ARTICLE_SAVED"
                    };
                }
                else
                {
                    return new SaveArticleResponse
                    {
                        Event = "ARTICLE_EXISTING_CODE_SAVED_FAILED"
                    };
                }
               
            }
            catch (Exception ex)
            {
                return new SaveArticleResponse
                {
                    Event = "ARTICLE_SAVED_FAILED"
                };
            }
        }
    }
}
