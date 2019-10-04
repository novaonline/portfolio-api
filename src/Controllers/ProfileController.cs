using core.Domains.Profiles.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Model = PortfolioApi.Models.Profiles;

namespace PortfolioApi.Controllers
{
    public class ProfileController : PortfolioController
    {
        private readonly IProfilesService _profileService;
        
        public ProfileController(IProfilesService profileService) : base()
        {
            _profileService = profileService;
        }

        //https://github.com/domaindrivendev/Swashbuckle.AspNetCore
        //https://github.com/Microsoft/api-guidelines/blob/master/Guidelines.md
        // GET api/profile
        [HttpGet, AllowAnonymous]
        [Produces(typeof(IEnumerable<Model.Profile>))]
        public IActionResult Get()
        {
            return Ok(_profileService.GetAll());
        }
    }
}
