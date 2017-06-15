using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioApi.Services;
using Model = PortfolioApi.Models.RankableItems.Frameworks;
using Rank = PortfolioApi.Models.RankableItems.Ranks.Rank;

namespace PortfolioApi.Controllers
{
    [Route("api/[controller]")]
    public class FrameworksController : PortfolioController
    {
        public FrameworksController(PortfolioContext context) : base(context)
        {
        }

        [HttpGet, AllowAnonymous]
        [Produces(typeof(IEnumerable<Model.Framework>))]
        public IActionResult Get()
        {
            return Ok(_context.Frameworks
            .Include(f => f.Rank)
            .ToList());
        }

        [HttpGet, AllowAnonymous]
        [Produces(typeof(Model.Framework))]
        [Route("GetById")]
        public IActionResult GetById(int id)
        {
            return Ok(
                _context.Frameworks
                .Include(f => f.Rank)
                .SingleOrDefault(x => x.Id == id)
            );
        }

        [HttpPost]
        [Produces(typeof(int))]
        public IActionResult Post([FromBody] Model.Framework model)
        {
            if (!ModelState.IsValid)
            {
                BadRequest(ModelState);
            }
            try
            {
                var result = _context.Frameworks.Add(model);
                _context.SaveChanges();
                return Created("Created Successfully with Id", result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Produces(typeof(Model.Framework))]
        public IActionResult Put([FromQuery]int id, [FromBody] Model.Info model)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid Id");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var modelFromContext = _context.Frameworks.Find(id);
                modelFromContext.Info = model;
                _context.SaveChanges();
                return Ok(modelFromContext);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Produces(typeof(Model.Framework))]
        [Route("UpdateRank")]
        public IActionResult UpdateRank([FromQuery]int id, [FromBody] Rank model)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid Id");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var modelFromContext = _context.Frameworks.Find(id);
                modelFromContext.Rank = model;
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
                var modelToDelete = _context.Frameworks.Find(frameworksAndLibsId);
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
