using Article_Management_Backend.ReadModel.Interfaces.Repositories;
using Article_Management_Backend.Commands;
using MediatR;
using Article_Management_Backend.ReadModel.Entities;
namespace Article_Management_Backend.CommandHandlers
{
    public class DeleteArticleCommandHandler : IRequestHandler<DeleteArticleCommand, DeleteArticleResponse>
    {
        private readonly IArticleRepository _articleRepository;

        public DeleteArticleCommandHandler(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task<DeleteArticleResponse> Handle(DeleteArticleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _articleRepository.DeleteArticle(request.ArticleId, cancellationToken);

                return new DeleteArticleResponse
                {
                    Event = "ARTICLE_DELETED"
                };
            }
            catch (Exception ex)
            {
                return new DeleteArticleResponse
                {
                    Event = "ARTICLE_DELETED_FAILED"
                };
            }
        }
    }
}
