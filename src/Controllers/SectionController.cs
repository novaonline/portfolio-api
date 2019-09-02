﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioApi.Repository.EntityFramework.Context;
using System;
using System.Linq;
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
            if (contents == null)
            {
                return BadRequest("Id not found");
            }
            return Ok(contents);
        }

        [HttpPost("{contentId}")]
        [Produces(typeof(int))]
        public IActionResult Post(int contentId, [FromBody] Model.Info model)
        {
            if (_context.Contents.Find(contentId) == null)
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
        public IActionResult Delete(int sectionId)
        {
            try
            {
                var modelToDelete = _context.Sections.Find(sectionId);
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
}
