namespace Git.Services
{
    using System.Collections.Generic;

    using Git.Models.Repositpries;

    public interface IRepositoriesService
    {

        string GetRepositoryNameById(string commitId);

        IEnumerable<RepositoryViewModel> GetAllPublicRepository();

        void CreateRepository(string name, string type, string userId);
    }
}
