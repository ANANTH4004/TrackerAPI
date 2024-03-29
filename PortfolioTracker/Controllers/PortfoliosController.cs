﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioTracker.Models;

namespace PortfolioTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfoliosController : ControllerBase
    {
        private readonly TrackerContext _context;

        public PortfoliosController(TrackerContext context)
        {
            _context = context;
        }

        // GET: api/Portfolios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Portfolio>>> GetPortfolios()
        {
            return await _context.Portfolios.ToListAsync();
        }

        // GET: api/Portfolios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Portfolio>> GetPortfolio(Guid id)
        {
            var portfolio = await _context.Portfolios.FindAsync(id);

            if (portfolio == null)
            {
                return NotFound();
            }

            return portfolio;
        }

        // PUT: api/Portfolios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPortfolio(Guid id, Portfolio portfolio)
        {
            if (id != portfolio.portfpolioId)
            {
                return BadRequest();
            }

            _context.Entry(portfolio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PortfolioExists(id))
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

        // POST: api/Portfolios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Portfolio>> PostPortfolio(Portfolio portfolio)
        {
            _context.Portfolios.Add(portfolio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPortfolio", new { id = portfolio.portfpolioId }, portfolio);
        }

        // DELETE: api/Portfolios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePortfolio(Guid id)
        {
            var portfolio = await _context.Portfolios.FindAsync(id);
            if (portfolio == null)
            {
                return NotFound();
            }

            _context.Portfolios.Remove(portfolio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PortfolioExists(Guid id)
        {
            return _context.Portfolios.Any(e => e.portfpolioId == id);
        }
        [HttpGet("userName/{userName}")]
        public async Task<ActionResult<IEnumerable<Portfolio>>> GetPortfolioU(string userName)
        {
            var portfolio = await _context.Portfolios.Where(x => x.UserName == userName).ToListAsync();
            //var portfolio = await _context.Portfolios.FindAsync(userName);

            if (!portfolio.Any())
            {
                return NotFound("User dont have a Portfolio");
            }

            return portfolio;
        }
    }
}
