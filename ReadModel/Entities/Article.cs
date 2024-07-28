using Microsoft.AspNetCore.Http.HttpResults;

namespace Article_Management_Backend.ReadModel.Entities
{
    public class Article
    {
        public Guid ArticleId { get; set; }
        public string ArticleCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid ArticleCategoryId { get; set; }
        public Guid ArticleStatusId { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid CreatedBy { get; set; }

        public ArticleCategory ArticleCategory { get; set; }
        public ArticleStatus ArticleStatus { get; set; }
    }
}
