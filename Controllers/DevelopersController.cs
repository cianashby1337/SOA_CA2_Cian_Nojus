﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SOA_CA2_Cian_Nojus.Authentication;
using SOA_CA2_Cian_Nojus.Data;
using SOA_CA2_Cian_Nojus.Models;
using SOA_CA2_Cian_Nojus.DTOs;
using Asp.Versioning;


namespace SOA_CA2_Cian_Nojus.Controllers
{
    // Developers controller
    [Route("api/v{version:apiVersion}/developers")]

    // versioning
    [ApiVersion("1.0")]
    [ApiController]
    [ServiceFilter(typeof(ApiKeyAuthFilter))]
    public class DevelopersController : ControllerBase
    {
        private readonly SOA_CA2_Cian_NojusContext _context;

        public DevelopersController(SOA_CA2_Cian_NojusContext context)
        {
            _context = context;
			context.Database.EnsureCreated();
		}

        // GET: api/Developers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeveloperDTO>>> GetDeveloper()
        {

            // Get all developers
            var developers = await _context.Developer.Include(g => g.Games).ToListAsync();
            return developers.Select(g => new DeveloperDTO
            {
                id = g.Id,
                name = g.name,
                country = g.country,
                games = g.Games.Select(g => g.title).ToList()
            }).ToList();
        }

        // GET: api/Developers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DeveloperDTO>> GetDeveloper(int id)
        {
            // Get developer by id
            var developer = await _context.Developer.Include(g => g.Games).FirstOrDefaultAsync(d => d.Id == id);

            if (developer == null)
            {
                return NotFound();
            }

            return new DeveloperDTO
            {
                id = developer.Id,
                name = developer.name,
                country = developer.country,
                games = developer.Games.Select(g => g.title).ToList()
            };
        }

        // PUT: api/Developers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]

        // Update developer
        public async Task<IActionResult> PutDeveloper(int id, DeveloperDTO developerDTO)
        {
            if (id != developerDTO.id)
            {
                return BadRequest();
            }

            // Get developer by id
            var developer = await _context.Developer.FindAsync(id);
            if (developer == null)
            {
                return NotFound();
            }

            developer.name = developerDTO.name;
            developer.country = developerDTO.country;


            if (developerDTO.games != null)
            {
                foreach (var gameDTO in developerDTO.games)
                {
                    var game = await _context.Games.FindAsync(gameDTO);
                    if (game != null)
                    {
                        _context.Games.Add(new Games
                        {
                            title = game.title,
                            genre = game.genre,
                            release_year = game.release_year,
                        });
                    }
                }
            }

            // Update developer
            _context.Entry(developer).State = EntityState.Modified;



            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeveloperExists(id))
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

        // POST: api/Developers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DeveloperDTO>> PostDeveloper(DeveloperDTO developerDTO)
        {
            var developer = new Developer
            {
                name = developerDTO.name,
                country = developerDTO.country
            };

            _context.Developer.Add(developer);
            await _context.SaveChangesAsync();

            developerDTO.id = developer.Id;
            return CreatedAtAction("GetDeveloper", new { id = developer.Id }, developerDTO);
        }

        // DELETE: api/Developers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeveloper(int id)
        {
            var developer = await _context.Developer.FindAsync(id);
            if (developer == null)
            {
                return NotFound();
            }

            _context.Developer.Remove(developer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Check if developer exists
        private bool DeveloperExists(int id)
        {
            return _context.Developer.Any(e => e.Id == id);
        }
    }
}
