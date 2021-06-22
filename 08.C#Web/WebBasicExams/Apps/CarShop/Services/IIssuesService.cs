namespace CarShop.Services
{
    using CarShop.Models.Issues;
    public interface IIssuesService
    {
        public CarIssuesViewModel GetCarIssuesByCarId(string carId);

        void AddIssueToCar(string carId, string description);

        public void FixedIssue(string cardId, string issueId);

        void DeleteIssue(string cardId, string issueId);
    }
}
