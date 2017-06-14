using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioApi.Services;
using Model = PortfolioApi.Models.FrameworksAndLibs;

namespace PortfolioApi.Controllers
{
    [Route("api/[controller]")]
    public class FrameworksAndLibsController : PortfolioController
    {
        public FrameworksAndLibsController(PortfolioContext context) : base(context)
        {
        }

        [HttpGet, AllowAnonymous]
        [Produces(typeof(IEnumerable<Model>))]
        public IActionResult Get()
        {
            return Ok(_context.FrameworksAndLibs
            .Include(f => f.Rank)
            .ToList());
        }

        [HttpPost]
        [Produces(typeof(int))]
        public IActionResult Post([FromBody] Model model)
        {
            if(!ModelState.IsValid) {
                BadRequest(ModelState);
            }
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
                _context.FrameworksAndLibs.Add(createdModel);
                _context.SaveChanges();
                return Created("Created Successfully with Id", createdModel.FrameworksAndLibsId);
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
            if (model.FrameworksAndLibsId <= 0)
            {
                return BadRequest("Id must be provided");
            }
            try
            {
                var modelFromContext = _context.FrameworksAndLibs.Find(model.FrameworksAndLibsId);

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
        public IActionResult Delete(int frameworksAndLibsId)
        {
            try
            {
                var modelToDelete = _context.FrameworksAndLibs.Find(frameworksAndLibsId);
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
