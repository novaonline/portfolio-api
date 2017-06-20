using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioApi.Services;
using Model = PortfolioApi.Models.Contents;
using ContentInputModel = PortfolioApi.Models.Contents.InputGroup;

namespace PortfolioApi.Controllers
{
    [Route("api/[controller]")]
    public class ContentController : PortfolioController
    {
        public ContentController(PortfolioContext context) : base(context)
        {
        }

        [HttpGet, AllowAnonymous]
        [Produces(typeof(IEnumerable<Model.Content>))]
        public IActionResult Get()
        {
            var contents = _context.Contents
                .Include(c => c.Info).ToList(); // not sure why include does not allow me to do multiple
            contents = contents.Select(content =>
            {
                content.Sections = _context.Sections.Include(y => y.Info).Where(x => x.ContentId == content.Id).ToList();
                return content;
            }).ToList();
            return Ok(contents.ToList());
        }

        [HttpGet("{id}"), AllowAnonymous]
        [Produces(typeof(Model.Content))]
        public IActionResult Get(int id)
        {
            var content = _context.Contents
                .Include(c => c.Info).SingleOrDefault(x => x.Id == id); // not sure why include does not allow me to do multiple
            content.Sections = _context.Sections.Include(y => y.Info).Where(x => x.ContentId == id).ToList();
            return Ok(content);
        }

        [HttpPost]
        [Produces(typeof(int))]
        public IActionResult Post([FromBody] ContentInputModel model)
        {
            if (!ModelState.IsValid)
            {
                BadRequest(ModelState);
            }
            try
            {
                var content = new Model.Content
                {
                    Info = model.ContentInfo,
                    HtmlId = model.HtmlId,
                };
                foreach (var secInfo in model.SectionInfo)
                {
                    content.Sections.Add(new Model.Sections.Section() { Info = secInfo });
                }
                _context.Contents.Add(content);
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
            if (id <= 0)
            {
                return BadRequest("Id must be provided");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var modelFromContext = _context.Contents.Include(x => x.Info).Single(x => x.Id == id);

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
