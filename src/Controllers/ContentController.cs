using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioApi.Services;
using Model = PortfolioApi.Models.Content;

namespace PortfolioApi.Controllers
{
    [Route("api/[controller]")]
    public class ContentController : PortfolioController
    {
        public ContentController(PortfolioContext context) : base(context)
        {
        }

        [HttpGet, AllowAnonymous]
        [Produces(typeof(IEnumerable<Model>))]
        public IActionResult Get()
        {
            return Ok(_context.Contents
            .Include(c => c.Sections)
            .ToList());
        }

        [HttpPost]
        [Produces(typeof(int))]
        public IActionResult Post([FromBody] Model model)
        {
            if(!ModelState.IsValid) {
                BadRequest(ModelState);
            }
            try
            {
                _context.Contents.Add(model);
                _context.SaveChanges();
                return Created("Created Successfully with Id", model.ContentId);
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
            if (model.ContentId <= 0)
            {
                return BadRequest("Id must be provided");
            }
            try
            {
                var modelFromContext = _context.Contents.Find(model.ContentId);

                modelFromContext.Sections = model.Sections;
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
        public IActionResult Delete(int contentId)
        {
            try
            {
                var modelToDelete = _context.Contents.Find(contentId);
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
