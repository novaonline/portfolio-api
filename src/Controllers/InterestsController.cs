using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioApi.Repository.EntityFramework.Context;
using System;
using System.Collections.Generic;
using System.Linq;
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
            return Ok(_context.Interests
            .Include(i => i.Info)
            .ToList());
        }

        [HttpGet("{id}"), AllowAnonymous]
        [Produces(typeof(Model.Interest))]
        public IActionResult Get(int id)
        {
            var m = _context.Interests
            .Include(i => i.Info).SingleOrDefault(x => x.Id == id);
            if (m == null)
            {
                BadRequest("Id not found");
            }
            return Ok(m);
        }



        [HttpPost]
        [Produces(typeof(int))]
        public IActionResult Post([FromBody] Model.Info model)
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
                var m = new Model.Interest
                {
                    Info = model
                };
                _context.Interests.Add(m);
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
                var modelFromContext = _context.Interests.Include(x => x.Info).Single(x => x.Id == id);
                if(modelFromContext == null)
                {
                    BadRequest("Id not found");
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
        public IActionResult Delete(int interestId)
        {
            try
            {
                var modelToDelete = _context.Interests.Find(interestId);
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
