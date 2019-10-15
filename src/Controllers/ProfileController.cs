using core.Domains.Profiles.Interfaces;
using Microsoft.AspNetCore.Mvc;
using PortfolioApi.Helpers.Templates;
using PortfolioApi.Models.Helpers;
using PortfolioApi.Models.Profiles;


namespace PortfolioApi.Controllers
{
    public class ProfileController : PortfolioController
    {
        private readonly IProfilesService _profileService;

        public ProfileController(IProfilesService profileService) : base()
        {
            _profileService = profileService;
        }

        [HttpGet, Produces(typeof(ServiceMessages<Profile>))]
        public IActionResult Get(Profile searchTerm) => Respond(_profileService.Read(searchTerm));

        [HttpGet(RouteTemplates.Id), Produces(typeof(ServiceMessages<Profile>))]
        public IActionResult Get(int Id) => Respond(_profileService.Read(new Profile(Id)));

        [HttpPost, Produces(typeof(ServiceMessage<Profile>))]
        public IActionResult Post(Profile profile) => Respond(_profileService.Create(profile));

        [HttpPut(RouteTemplates.Id), Produces(typeof(ServiceMessage<Profile>))]
        public IActionResult Put(int Id, ProfileInfo profileInfo) => Respond(_profileService.Update(new Profile(Id), profileInfo));

        [HttpDelete(RouteTemplates.Id), Produces(typeof(ServiceMessage<Profile>))]
        public IActionResult Delete(int Id) => Respond(_profileService.Delete(new Profile(Id)));
    }
}
