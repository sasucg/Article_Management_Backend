using Article_Management_Backend.ReadModel.Interfaces.Repositories;
using Article_Management_Backend.Commands;
using MediatR;
using Article_Management_Backend.ReadModel.Entities;
namespace Article_Management_Backend.CommandHandlers
{
    public class UpdateArticleCommandHandler : IRequestHandler<UpdateArticleCommand, UpdateArticleResponse>
    {
        private readonly IArticleRepository _articleRepository;

        public UpdateArticleCommandHandler(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task<UpdateArticleResponse> Handle(UpdateArticleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Article article = await _articleRepository.GetArticleById(request.ArticleId, cancellationToken);

                article.ArticleId = request.ArticleId;
                article.ArticleStatusId = request.ArticleStatusId;
                article.ArticleCode = request.ArticleCode;
                article.ArticleCategoryId = request.ArticleCategoryId;
                article.Name = request.Name;
                article.Description = request.Description;

                await _articleRepository.UpdateArticle(article, cancellationToken);

                return new UpdateArticleResponse
                {
                    Event = "ARTICLE_UPDATED"
                };
            }
            catch (Exception ex)
            {
                return new UpdateArticleResponse
                {
                    Event = "ARTICLE_UPDATED_FAILED"
                };
            }
        }
    }
}
