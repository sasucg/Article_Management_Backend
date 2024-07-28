namespace Article_Management_Backend.ReadModel.Entities
{
    public class ArticleCategory
    {
        public Guid ArticleCategoryId { get; set; }
        public string ArticleCategoryName { get; set; }
        public string ArticleCategoryCode { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid CreatedBy { get; set; }
    }
}
