namespace Git.Controllers
{
    using Git.Models.Repositpries;
    using Git.Services;

    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using System.Linq;

    public class RepositoriesController : Controller
    {
        private readonly IValidator validator;
        private readonly IRepositoriesService repositoriesService;

        public RepositoriesController(
            IValidator validator,
            IRepositoriesService repositoriesService)
        {
            this.validator = validator;
            this.repositoriesService = repositoriesService;
        }

        public HttpResponse All()
        {
            var repositories = this.repositoriesService
                .GetAllPublicRepository();

            return this.View(repositories);
        }

        [Authorize]
        public HttpResponse Create()
            => this.View();

        [HttpPost]
        [Authorize]
        public HttpResponse Create(RepositoryFormModel input)
        {
            var errors = this.validator.ValidateRepositoryFormModel(input);

            if (errors.Any())
            {
                return this.Error(errors);
            }

            this.repositoriesService
                .CreateRepository(
                    input.Name,
                    input.RepositoryType,
                    this.User.Id);

            return this.Redirect("/Repositories/All");
        }
    }
}
