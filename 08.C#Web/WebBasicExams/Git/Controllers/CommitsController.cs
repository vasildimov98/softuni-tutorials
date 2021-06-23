namespace Git.Controllers
{
    using Git.Models.Commits;
    using Git.Services;

    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using System;
    using System.Linq;

    public class CommitsController : Controller 
    {
        private readonly IValidator validator;
        private readonly ICommitsService commitsService;
        private readonly IRepositoriesService repositoriesService;

        public CommitsController(
            IValidator validator,
            ICommitsService commitsService,
            IRepositoriesService repositoriesService)
        {
            this.validator = validator;
            this.commitsService = commitsService;
            this.repositoriesService = repositoriesService;
        }

        [Authorize]
        public HttpResponse All()
        {
            var commits = this.commitsService
                .GetAllCommitsByUserId(this.User.Id);

            return this.View(commits);
        }

        [Authorize]
        public HttpResponse Create(string id)
        {
            var name = this.repositoriesService
                    .GetRepositoryNameById(id);

            if (name == null)
            {
                return this.BadRequest();
            }

            var model = new CommitCreateViewModel
            {
                Id = id,
                Name = name,
            };

            return this.View(model);
        }

        [HttpPost]
        [Authorize]
        public HttpResponse Create(CommitFormModel input)
        {
            var errors = this.validator.ValidateCommitFormModel(input);

            if (errors.Any())
            {
                return this.Error(errors);
            }

            this.commitsService
                .CreateCommit(input.Description, input.Id, this.User.Id);

            return this.Redirect("/Repositories/All");
        }

        [Authorize]
        public HttpResponse Delete(string id)
        {
            try
            {
                this.commitsService
                    .DeleteCommit(id);

                return this.Redirect("/Repositories/All");
            }
            catch (Exception ex)
            {
                return this.Error(ex.Message);
            }
        }
    }
}
