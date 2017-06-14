using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioApi.Services;
using Model = PortfolioApi.Models.Language;

namespace PortfolioApi.Controllers
{
    [Route("api/[controller]")]
    public class LanguagesController : PortfolioController
    {
        public LanguagesController(PortfolioContext context) : base(context)
        {
        }

        [HttpGet, AllowAnonymous]
        [Produces(typeof(Model))]
        public IActionResult Get()
        {
            return Ok(_context.Languages.Include(l => l.Rank));
        }

        [HttpGet, AllowAnonymous]
        [Produces(typeof(IEnumerable<Model>))]
        [Route("SearchByTitle")]
        public IActionResult SearchByTitle(string searchTerm)
        {
            IQueryable<Model> query = from l in _context.Languages
                               where l.Title.Contains(searchTerm)
                               select l;
            return Ok(query.Include(q=>q.Rank).ToList());
        }

        [HttpPost]
        [Produces(typeof(int))]
        public IActionResult Post([FromBody] Model model)
        {
            Model createdModel;
            try
            {
                createdModel = new Model()
                {
                    Description = model.Description,
                    Title = model.Title,
                    RankId = model.RankId,
                };
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            try
            {
                _context.Languages.Add(createdModel);
                _context.SaveChanges();
                return Created("Created Successfully with Id", createdModel.LanguageId);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Produces(typeof(Model))]
        public IActionResult Put([FromBody] Model model)
        {
            if (model.LanguageId <= 0)
            {
                return BadRequest("LanguageId must be provided");
            }
            try
            {
                var modelFromContext = _context.Languages.Find(model.LanguageId);

                modelFromContext.Description = string.IsNullOrEmpty(model.Description) ?
                modelFromContext.Description : model.Description;
                modelFromContext.Title = string.IsNullOrEmpty(model.Title) ?
                modelFromContext.Title : model.Title;
                modelFromContext.RankId = model.RankId <= 0 ?
                modelFromContext.RankId : model.RankId;
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
