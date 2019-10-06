using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioApi.Domains.Experiences.Interfaces;
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

        [HttpGet("{searchTerm}"), AllowAnonymous]
        [Produces(typeof(ServiceMessages<Experience>))]
        public IActionResult Get(Experience searchTerm)
        {
            return Respond(_experiencesService.Read(searchTerm));
        }
    }
}
