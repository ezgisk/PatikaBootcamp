﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Survivor;
using Survivor.Data.Entities;

[Route("api/[controller]")]
[ApiController]
public class CompetitorController : ControllerBase
{
    private readonly SurvivorContext _context;

    public CompetitorController(SurvivorContext context)
    {
        _context = context;
    }

    // GET /api/competitors
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Competitor>>> GetCompetitors()
    {
        return await _context.Competitors.Include(c => c.Category).ToListAsync();
    }

    // GET /api/competitors/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Competitor>> GetCompetitor(int id)
    {
        var competitor = await _context.Competitors.Include(c => c.Category).FirstOrDefaultAsync(c => c.Id == id);

        if (competitor == null)
        {
            return NotFound();
        }

        return competitor;
    }

    // GET /api/competitors/categories/{categoryId}
    [HttpGet("categories/{categoryId}")]
    public async Task<ActionResult<IEnumerable<Competitor>>> GetCompetitorsByCategory(int categoryId)
    {
        var competitors = await _context.Competitors.Where(c => c.CategoryId == categoryId).ToListAsync();

        if (!competitors.Any())
        {
            return NotFound();
        }

        return competitors;
    }

    // POST /api/competitors
    [HttpPost]
    public async Task<ActionResult<Competitor>> CreateCompetitor(Competitor competitor)
    {
        _context.Competitors.Add(competitor);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetCompetitor), new { id = competitor.Id }, competitor);
    }

    // PUT /api/competitors/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCompetitor(int id, Competitor competitor)
    {
        if (id != competitor.Id)
        {
            return BadRequest();
        }

        _context.Entry(competitor).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Competitors.Any(e => e.Id == id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // DELETE /api/competitors/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCompetitor(int id)
    {
        var competitor = await _context.Competitors.FindAsync(id);
        if (competitor == null)
        {
            return NotFound();
        }

        
        _context.Competitors.Remove(competitor);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
