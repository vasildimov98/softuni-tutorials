namespace Git.Services
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Git.Data;
    using Git.Data.Models;
    using Git.Models.Commits;

    public class CommitsService : ICommitsService
    {
        private readonly ApplicationDbContext dbContext;

        public CommitsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void CreateCommit(string description, string repositoryId, string userId)
        {
            var commit = new Commit
            {
                Description = description,
                RepositoryId = repositoryId,
                CreatedOn = DateTime.UtcNow,
                CreatorId = userId,
            };

            this.dbContext.Commits
                .Add(commit);

            this.dbContext
                .SaveChanges();
        }

        public void DeleteCommit(string commitId)
        {
            var commit = this.dbContext.Commits
                .Find(commitId);

            var repositories = this.dbContext.Repositories
                .Where(x => x.Commits.Any(x => x.Id == commitId))
                .ToList();

            foreach (var repo in repositories)
            {
                repo.Commits.Remove(commit);
            }

            dbContext.Commits.Remove(commit);

            dbContext.SaveChanges();
        }

        public IEnumerable<CommitViewModel> GetAllCommitsByUserId(string userId)
            => this.dbContext.Commits
                .Where(x => x.CreatorId == userId)
                .Select(x => new CommitViewModel
                {
                    Id = x.Id,
                    Description = x.Description,
                    CreatedOn = x.CreatedOn.ToString("O"),
                    Repository = x.Repository.Name,
                })
                .ToList();
    }
}
