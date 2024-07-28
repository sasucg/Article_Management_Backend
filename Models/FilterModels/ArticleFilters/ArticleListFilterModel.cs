namespace Article_Management_Backend.Models.FilterModels.ArticleFilters
{
    public class ArticleListFilterModel
    {
        public Guid? CategoryId { get; set; }
        public Guid? StatusId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }

    }
}
