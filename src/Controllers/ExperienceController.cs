using core.Domains.Experiences.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioApi.Models.Experiences;
using PortfolioApi.Models.Helpers;
using System;
using System.Linq;

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
        [Produces(typeof(ServiceMessage<Experience>))]
        public IActionResult Get(Experience searchTerm)
        {
            return Respond(_experiencesService.Get(searchTerm));
        }
    }
}
