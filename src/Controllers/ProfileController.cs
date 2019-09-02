using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioApi.Repository.EntityFramework.Context;
using System.Linq;
using Model = PortfolioApi.Models.Profiles;

namespace PortfolioApi.Controllers
{
	[Route("api/[controller]")]
    public class ProfileController : PortfolioController
    {
        public ProfileController(PortfolioContext context) : base(context)
        {
        }

        //https://github.com/domaindrivendev/Swashbuckle.AspNetCore
        //https://github.com/Microsoft/api-guidelines/blob/master/Guidelines.md
        // GET api/profile
        [HttpGet, AllowAnonymous]
        [Produces(typeof(Model.Profile))]
        public IActionResult Get()
        {
            return Ok(
                _context.Profiles
                .Include(p => p.Info)
                .FirstOrDefault());
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Model.Info model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var profile = _context.Profiles.Include(x=>x.Info).SingleOrDefault(i => i.Id == id);
            if(profile == null)
            {
                return BadRequest("Id not found");
            }
            profile.Info.Update(model);
            _context.SaveChanges();
            return Ok();
        }
    }
}
