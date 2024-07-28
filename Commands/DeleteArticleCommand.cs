using MediatR;

namespace Article_Management_Backend.Commands
{
    public class DeleteArticleCommand : IRequest<DeleteArticleResponse>
    {
        public Guid ArticleId { get; set; }
    }

    public class DeleteArticleResponse
    {
        public string Event { get; set; }
    }
}
