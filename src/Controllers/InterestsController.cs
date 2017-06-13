using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using portfolio_api.Services;
using Model = portfolio_api.Models.Interest;

namespace portfolio_api.Controllers
{
    [Route("api/[controller]")]
    public class InterestsController : PortfolioController
    {
        public InterestsController(PortfolioContext context) : base(context)
        {
        }

        [HttpGet, AllowAnonymous]
        [Produces(typeof(Model))]
        public IActionResult Get()
        {
            return Ok(_context.Interests.ToList());
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
                    Description = model.Description
                };
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            try
            {
                _context.Interests.Add(createdModel);
                _context.SaveChanges();
                return Created("Created Successfully with Id", createdModel.InterestId);
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
            if (model.InterestId <= 0)
            {
                return BadRequest("Id must be provided");
            }
            try
            {
                var modelFromContext = _context.Interests.Find(model.InterestId);
                modelFromContext.Description = string.IsNullOrEmpty(model.Description) ?
                modelFromContext.Description : model.Description;
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
