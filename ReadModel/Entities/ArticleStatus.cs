namespace Article_Management_Backend.ReadModel.Entities
{
    public class ArticleStatus
    {
        public Guid ArticleStatusId { get; set; }
        public string ArticleStatusName { get; set; }
        public string ArticleStatusCode { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid CreatedBy { get; set; }
    }
}
