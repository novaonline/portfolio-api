﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioApi.Domains.Experiences.Interfaces;
using PortfolioApi.Helpers.Templates;
using PortfolioApi.Models.Experiences;
using PortfolioApi.Models.Helpers;

namespace PortfolioApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class ExperienceController : PortfolioController
    {
        private readonly IExperiencesService _experiencesService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="experienceService"></param>
        /// <returns></returns>
        public ExperienceController(IExperiencesService experienceService) : base()
        {
            _experiencesService = experienceService;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <returns></returns>
        [HttpGet, AllowAnonymous, Produces(typeof(ServiceMessages<Experience>))]
        public IActionResult Get(Experience searchTerm) => Respond(_experiencesService.Read(searchTerm, RequestContext));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet(RouteTemplates.Id), AllowAnonymous, Produces(typeof(ServiceMessage<Experience>))]
        public IActionResult Get(int Id) => Respond(_experiencesService.Read(new Experience(Id), RequestContext));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="experience"></param>
        /// <returns></returns>
        [HttpPost, Produces(typeof(ServiceMessage<Experience>))]
        public IActionResult Post([FromBody]Experience experience) => Respond(_experiencesService.Create(experience, RequestContext));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="experienceInfo"></param>
        /// <returns></returns>
        [HttpPut(RouteTemplates.Id), Produces(typeof(ServiceMessage<Experience>))]
        public IActionResult Put(int Id, [FromBody]ExperienceInfo experienceInfo) => Respond(_experiencesService.Update(new Experience(Id), experienceInfo, RequestContext));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete(RouteTemplates.Id), Produces(typeof(ServiceMessage<Experience>))]
        public IActionResult Delete(int Id) => Respond(_experiencesService.Delete(new Experience(Id), RequestContext));

    }
}
