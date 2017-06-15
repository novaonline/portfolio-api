using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioApi.Services;
using Model = PortfolioApi.Models.RankableItems.Languages;

namespace PortfolioApi.Controllers
{
    [Route("api/[controller]")]
    public class LanguagesController : PortfolioController
    {
        public LanguagesController(PortfolioContext context) : base(context)
        {
        }

        [HttpGet, AllowAnonymous]
        [Produces(typeof(Model.Language))]
        public IActionResult Get()
        {
            return Ok(_context.Languages.Include(l => l.Rank));
        }

        [HttpGet, AllowAnonymous]
        [Produces(typeof(IEnumerable<Model.Language>))]
        [Route("SearchByTitle")]
        public IActionResult SearchByTitle(string searchTerm)
        {
            IQueryable<Model.Language> query = from l in _context.Languages
                                               where l.Info.Title.Contains(searchTerm)
                                               select l;
            return Ok(query.Include(q => q.Rank).ToList());
        }

        [HttpPost]
        [Produces(typeof(int))]
        public IActionResult Post([FromBody] Model.Language model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _context.Languages.Add(model);
                var id = _context.SaveChanges();
                return Created("Created Successfully with Id", id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Produces(typeof(Model.Language))]
        public IActionResult Put([FromQuery] int id, [FromBody] Model.Info model)
        {
            if (id <= 0)
            {
                return BadRequest("Id is invalid");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var modelFromContext = _context.Languages.Find(id);
                modelFromContext.Info = model;
                _context.SaveChanges();
                return Ok(modelFromContext);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Produces(typeof(bool))]
        public IActionResult Delete(int languageId)
        {
            try
            {
                var modelToDelete = _context.Languages.Find(languageId);
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
