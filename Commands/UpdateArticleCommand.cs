using MediatR;

namespace Article_Management_Backend.Commands
{
    public class UpdateArticleCommand : IRequest<UpdateArticleResponse>
    {
        public Guid ArticleId { get; set; }
        public Guid ArticleCategoryId { get; set; }
        public string Name { get; set; }
        public string ArticleCode { get; set; }
        public string Description { get; set; }
        public Guid ArticleStatusId { get; set; }
    }

    public class UpdateArticleResponse
    {
        public string Event { get; set; }
    }
}
