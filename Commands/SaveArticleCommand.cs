using MediatR;

namespace Article_Management_Backend.Commands
{
    public class SaveArticleCommand : IRequest<SaveArticleResponse>
    {
        public Guid ArticleCategoryId { get; set; }
        public string Name { get; set; }
        public string ArticleCode { get; set; }
        public string Description { get; set; }
        public Guid ArticleStatusId { get; set; }
    }

    public class SaveArticleResponse
    {
        public string Event { get; set; }
    }
}
