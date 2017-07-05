using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioApi.Services;
using Model = PortfolioApi.Models.RankableItems.Languages;
using Microsoft.AspNetCore.Cors;

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
        [EnableCors("AllowSpecificOrigin")]
        public IActionResult Get()
        {
            var lang = _context.Languages
            .Include(l => l.Info)
            .Include(l => l.Rank)
            .ThenInclude(x=>x.Info).OrderByDescending(x=>x.RankId);
            return Ok(lang);
        }

        [HttpGet("{id}"), AllowAnonymous]
        [Produces(typeof(Model.Language))]
        [EnableCors("AllowSpecificOrigin")]
        public IActionResult Get(int id)
        {
            var m = _context.Languages
            .Include(l => l.Info)
            .Include(l => l.Rank).SingleOrDefault(x => x.Id == id);
            if (m == null)
            {
                return BadRequest("Id not found");
            }
            return Ok();
        }


        [HttpGet, AllowAnonymous]
        [Produces(typeof(IEnumerable<Model.Language>))]
        [Route("SearchByTitle")]
        public IActionResult SearchByTitle(string searchTerm)
        {
            IQueryable<Model.Language> query = from l in _context.Languages
                                               where l.Title.Contains(searchTerm)
                                               select l;
            return Ok(query
            .Include(q => q.Info)
            .Include(q => q.Rank).ToList());
        }

        [HttpPost]
        [Produces(typeof(int))]
        public IActionResult Post([FromBody] LanguageInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var language = new Model.Language
                {
                    Info = model.LanguageInfo,
                    Title = model.Title,
                    RankId = model.RankId
                };
                _context.Languages.Add(language);
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
                var modelFromContext = _context.Languages.Include(x => x.Info).Single(x => x.Id == id);
                if(modelFromContext == null)
                {
                    return BadRequest("Id not found");
                }
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
        public IActionResult Delete(int languageId)
        {
            try
            {
                var modelToDelete = _context.Languages.Find(languageId);
                if (modelToDelete == null)
                {
                    return BadRequest("Id not found");
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
    public class LanguageInputModel
    {
        public int RankId { get; set; }
        public string Title { get; set; }
        public Model.Info LanguageInfo { get; set; }
    }
}
