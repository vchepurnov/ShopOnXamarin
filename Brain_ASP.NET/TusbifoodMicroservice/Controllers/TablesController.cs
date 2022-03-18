using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using TusbifoodMicroservice.Context;

namespace TusbifoodMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TablesController : ControllerBase
    {
        private readonly TusbiFoodContext _context;

        public TablesController(TusbiFoodContext context)
        {
            _context = context;
        }

        // GET: api/Tables
        [Route("Tables")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Table>>> GetTables()
        {
            return await _context.Table.ToListAsync();
        }

        // GET: api/Tables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Table>> GetTable(int id)
        {
            var table = await _context.Table.FindAsync(id);

            if (table == null)
            {
                return NotFound();
            }

            return table;
        }
        [Route("Get-Seats")]
        [HttpGet]
        public async Task<List<int>> GetSeats(int tableId) => _context.Seats.Where(e => e.TableId == tableId).Select(a => a.Id).ToList<int>();
        private bool TableExists(int id)
        {
            return _context.Table.Any(e => e.Id == id);
        }
    }
}
