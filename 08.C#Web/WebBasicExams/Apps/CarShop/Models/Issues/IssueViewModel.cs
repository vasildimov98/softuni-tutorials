namespace CarShop.Models.Issues
{
    public class IssueViewModel
    {
        public string Id { get; init; } 

        public string Description { get; set; }

        public string IsFixed { get; set; }
    }
}