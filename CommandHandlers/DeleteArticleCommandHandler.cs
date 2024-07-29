using Article_Management_Backend.ReadModel.Interfaces.Repositories;
using Article_Management_Backend.Commands;
using MediatR;
using Article_Management_Backend.ReadModel.Entities;
using FluentValidation;
namespace Article_Management_Backend.CommandHandlers
{
    public class DeleteArticleCommandHandler : IRequestHandler<DeleteArticleCommand, DeleteArticleResponse>
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IValidator<DeleteArticleCommand> _validator;

        public DeleteArticleCommandHandler(IArticleRepository articleRepository, IValidator<DeleteArticleCommand> validator)
        {
            _articleRepository = articleRepository;
            _validator = validator;
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
