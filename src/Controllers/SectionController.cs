using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model = PortfolioApi.Models.Contents.Sections;

namespace PortfolioApi.Controllers
{
    [Route("api/[controller]")]
    public class SectionController : PortfolioController
    {
        public SectionController(PortfolioContext context) : base(context)
        {
        }

        [HttpGet("{id}"), AllowAnonymous]
        [Produces(typeof(Model.Section))]
        public IActionResult Get(int id)
        {
            var contents = _context.Sections
                .Include(c => c.Info).SingleOrDefault(x => x.Id == id);
            return Ok(contents);
        }

        [HttpPost("{contentId}")]
        [Produces(typeof(int))]
        public IActionResult Post(int contentId, [FromBody] Model.Info model)
        {
            if (_context.Sections.Find(contentId) == null)
            {
                return BadRequest("Content Id does not exist");
            }
            if (!ModelState.IsValid)
            {
                BadRequest(ModelState);
            }
            try
            {
                _context.Sections.Add(new Model.Section() { ContentId = contentId, Info = model });
                var id = _context.SaveChanges();
                return Created("Created Successfully with Id", id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Model.Info model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var modelFromContext = _context.Sections.Include(x => x.Info).Single(x => x.Id == id);

                modelFromContext.Info.Update(model);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Produces(typeof(bool))]
        public IActionResult Delete(int sectionId)
        {
            try
            {
                var modelToDelete = _context.Sections.Find(sectionId);
                if (modelToDelete == null)
                {
                    return NotFound();
                }
                _context.Remove(modelToDelete);
                _context.SaveChanges();
                return Ok(true);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
