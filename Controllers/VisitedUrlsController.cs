using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrowsingTimeTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BrowsingTimeTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitedUrlsController : ControllerBase
    {
        private readonly BrowsingTimeTrackerContext _context;

        public VisitedUrlsController(BrowsingTimeTrackerContext context)
        {
            _context = context;
        }

        /// GET: api/VisitedUrls
        [HttpGet]
        public IEnumerable<VisitedUrl> GetVisitedUrls()
        {
            var visitedUrls = _context.VisitedUrls.ToList();

            return visitedUrls;
        }

        /// GET: api/VisitedUrls/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VisitedUrl>> GetVisitedUrl(long id)
        {
            var visitedUrl = await _context.VisitedUrls.FindAsync(id);

            if (visitedUrl == null)
            {
                return NotFound();
            }

            return visitedUrl;
        }

        // POST: api/VisitedUrls
        [HttpPost]
        public async Task<ActionResult<VisitedUrl>> PostVisitedUrl(VisitedUrl visitedUrl)
        {
            _context.VisitedUrls.Add(visitedUrl);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetVisitedUrl), new { id = visitedUrl.Id }, visitedUrl);
        }

        // PUT: api/VisitedUrls/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVisitedUrl(long id, VisitedUrl visitedUrl)
        {
            if (id != visitedUrl.Id)
            {
                return BadRequest();
            }

            if (!VisitedUrlExists(id))
            {
                return NotFound();
            }

            _context.Entry(visitedUrl).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return NoContent();
        }

        // DELETE: api/VisitedUrls/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<VisitedUrl>> DeleteVisitedUrl(long id)
        {
            var visitedUrl = await _context.VisitedUrls.FindAsync(id);
            if (visitedUrl == null)
            {
                return NotFound();
            }

            _context.VisitedUrls.Remove(visitedUrl);
            await _context.SaveChangesAsync();

            return visitedUrl;
        }

        private bool VisitedUrlExists(long id)
        {
            return _context.VisitedUrls.Any(i => i.Id == id);
        }
    }
}
