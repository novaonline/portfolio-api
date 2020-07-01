using core.Domains.Profiles.Interfaces;
using Microsoft.AspNetCore.Mvc;
using PortfolioApi.Helpers.Templates;
using PortfolioApi.Models.Helpers;
using PortfolioApi.Models.Profiles;


namespace PortfolioApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class ProfileController : PortfolioController
    {
        private readonly IProfilesService _profileService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="profileService"></param>
        /// <returns></returns>
        public ProfileController(IProfilesService profileService) : base()
        {
            _profileService = profileService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <returns></returns>
        [HttpGet, Produces(typeof(ServiceMessages<Profile>))]
        public IActionResult Get(Profile searchTerm) => Respond(_profileService.Read(searchTerm));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet(RouteTemplates.Id), Produces(typeof(ServiceMessages<Profile>))]
        public IActionResult Get(int Id) => Respond(_profileService.Read(new Profile(Id)));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="profile"></param>
        /// <returns></returns>
        [HttpPost, Produces(typeof(ServiceMessage<Profile>))]
        public IActionResult Post([FromBody] Profile profile) => Respond(_profileService.Create(profile));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="profileInfo"></param>
        /// <returns></returns>
        [HttpPut(RouteTemplates.Id), Produces(typeof(ServiceMessage<Profile>))]
        public IActionResult Put(int Id, [FromBody] ProfileInfo profileInfo) => Respond(_profileService.Update(new Profile(Id), profileInfo));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete(RouteTemplates.Id), Produces(typeof(ServiceMessage<Profile>))]
        public IActionResult Delete(int Id) => Respond(_profileService.Delete(new Profile(Id)));
    }
}
