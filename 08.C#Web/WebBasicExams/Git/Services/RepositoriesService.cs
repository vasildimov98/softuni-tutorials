namespace Git.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Git.Data;
    using Git.Data.Models;
    using Git.Models.Repositpries;

    public class RepositoriesService : IRepositoriesService
    {
        private readonly ApplicationDbContext dbContext;

        public RepositoriesService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void CreateRepository(string name, string type, string userId)
        {
            var repository = new Repository
            {
                Name = name,
                IsPublic = type == "Public",
                CreatedOn = DateTime.UtcNow,
                OwnerId = userId,
            };

            this.dbContext.Repositories
                .Add(repository);

            this.dbContext.SaveChanges();
        }

        public IEnumerable<RepositoryViewModel> GetAllPublicRepository()
            => this.dbContext.Repositories
                .Where(x => x.IsPublic)
                .Select(x => new RepositoryViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    OwnerName = x.Owner.Username,
                    CreatedOn = x.CreatedOn.ToString("O"),
                    Commits = x.Commits.Count(),
                })
                .ToList();

        public string GetRepositoryNameById(string id)
            => this.dbContext.Repositories
                .Where(x => x.Id == id)
                .Select(x => x.Name)
                .FirstOrDefault();
    }
}
