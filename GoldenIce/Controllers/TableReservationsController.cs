﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GoldenIce.Models;

namespace GoldenIce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableReservationsController : ControllerBase
    {
        private readonly IceCreamContext _context;

        public TableReservationsController(IceCreamContext context)
        {
            _context = context;
        }

        // GET: api/TableReservations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TableReservation>>> GetTableReservation()
        {
            return await _context.TableReservation.ToListAsync();
        }

        // GET: api/TableReservations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TableReservation>> GetTableReservation(long id)
        {
            var tableReservation = await _context.TableReservation.FindAsync(id);

            if (tableReservation == null)
            {
                return NotFound();
            }

            return tableReservation;
        }

        // PUT: api/TableReservations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTableReservation(long id, TableReservation tableReservation)
        {
            if (id != tableReservation.Id)
            {
                return BadRequest();
            }

            _context.Entry(tableReservation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TableReservationExists(id))
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

        // POST: api/TableReservations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TableReservation>> PostTableReservation(TableReservation tableReservation)
        {
            _context.TableReservation.Add(tableReservation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTableReservation", new { id = tableReservation.Id }, tableReservation);
        }

        // DELETE: api/TableReservations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TableReservation>> DeleteTableReservation(long id)
        {
            var tableReservation = await _context.TableReservation.FindAsync(id);
            if (tableReservation == null)
            {
                return NotFound();
            }

            _context.TableReservation.Remove(tableReservation);
            await _context.SaveChangesAsync();

            return tableReservation;
        }

        private bool TableReservationExists(long id)
        {
            return _context.TableReservation.Any(e => e.Id == id);
        }
    }
}
