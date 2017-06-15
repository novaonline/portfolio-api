using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioApi.Services;
using Model = PortfolioApi.Models.Interests;

namespace PortfolioApi.Controllers
{
    [Route("api/[controller]")]
    public class InterestsController : PortfolioController
    {
        public InterestsController(PortfolioContext context) : base(context)
        {
        }

        [HttpGet, AllowAnonymous]
        [Produces(typeof(Model.Interest))]
        public IActionResult Get()
        {
            return Ok(_context.Interests.ToList());
        }

        [HttpPost]
        [Produces(typeof(int))]
        public IActionResult Post([FromBody] Model.Interest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            try
            {
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            try
            {
                _context.Interests.Add(model);
                var id = _context.SaveChanges();
                return Created("Created Successfully with Id", id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Produces(typeof(Model.Interest))]
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
                var modelFromContext = _context.Interests.Find(id);
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
        public IActionResult Delete(int interestId)
        {
            try
            {
                var modelToDelete = _context.Interests.Find(interestId);
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
