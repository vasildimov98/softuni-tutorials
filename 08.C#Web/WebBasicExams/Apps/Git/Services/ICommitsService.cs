namespace Git.Services
{
    using System.Collections.Generic;

    using Git.Models.Commits;

    public interface ICommitsService
    {
        IEnumerable<CommitViewModel> GetAllCommitsByUserId(string userId);

        void CreateCommit(string description, string repositoryId, string userId);

        void DeleteCommit(string commitId);
    }
}
