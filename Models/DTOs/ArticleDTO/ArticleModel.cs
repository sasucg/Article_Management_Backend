namespace Article_Management_Backend.Models.DTOs.ArticleDTO
{
    public class ArticleModel
    {
        public Guid ArticleId { get; set; }
        public string Name { get; set; }
        public string ArticleCode { get; set; }
        public string ArticleCategoryName { get; set; }
        public string ArticleStatusName { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
