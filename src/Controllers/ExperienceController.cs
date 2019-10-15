using Microsoft.AspNetCore.Mvc;
using PortfolioApi.Domains.Experiences.Interfaces;
using PortfolioApi.Helpers.Templates;
using PortfolioApi.Models.Experiences;
using PortfolioApi.Models.Helpers;

namespace PortfolioApi.Controllers
{
    public class ExperienceController : PortfolioController
    {
        private readonly IExperiencesService _experiencesService;

        public ExperienceController(IExperiencesService experienceService) : base()
        {
            _experiencesService = experienceService;
        }

        [HttpGet, Produces(typeof(ServiceMessages<Experience>))]
        public IActionResult Get(Experience searchTerm) => Respond(_experiencesService.Read(searchTerm));

        [HttpGet(RouteTemplates.Id), Produces(typeof(ServiceMessage<Experience>))]
        public IActionResult Get(int Id) => Respond(_experiencesService.Read(new Experience(Id)));

        [HttpPost, Produces(typeof(ServiceMessage<Experience>))]
        public IActionResult Post(Experience experience) => Respond(_experiencesService.Create(experience));

        [HttpPut(RouteTemplates.Id), Produces(typeof(ServiceMessage<Experience>))]
        public IActionResult Put(int Id, ExperienceInfo experienceInfo) => Respond(_experiencesService.Update(new Experience(Id), experienceInfo));

        [HttpDelete(RouteTemplates.Id), Produces(typeof(ServiceMessage<Experience>))]
        public IActionResult Delete(int Id) => Respond(_experiencesService.Delete(new Experience(Id)));

    }
}
