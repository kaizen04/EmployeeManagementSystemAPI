using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeManagementAPI.Models;

namespace EmployeeManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryReportsController : ControllerBase
    {
        private readonly EmployeeManagementDbContext _context;

        public SalaryReportsController(EmployeeManagementDbContext context)
        {
            _context = context;
        }

        // GET: api/SalaryReports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalaryReport>>> GetSalaryReports()
        {
            return await _context.SalaryReports.ToListAsync();
        }

        // GET: api/SalaryReports/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SalaryReport>> GetSalaryReport(string id)
        {
            var salaryReport = await _context.SalaryReports.FindAsync(id);

            if (salaryReport == null)
            {
                return NotFound();
            }

            return salaryReport;
        }

        // PUT: api/SalaryReports/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalaryReport(string id, SalaryReport salaryReport)
        {
            if (id != salaryReport.PAN)
            {
                return BadRequest();
            }

            _context.Entry(salaryReport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalaryReportExists(id))
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

        // POST: api/SalaryReports
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SalaryReport>> PostSalaryReport(SalaryReport salaryReport)
        {
            _context.SalaryReports.Add(salaryReport);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SalaryReportExists(salaryReport.PAN))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSalaryReport", new { id = salaryReport.PAN }, salaryReport);
        }

        // DELETE: api/SalaryReports/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalaryReport(string id)
        {
            var salaryReport = await _context.SalaryReports.FindAsync(id);
            if (salaryReport == null)
            {
                return NotFound();
            }

            _context.SalaryReports.Remove(salaryReport);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SalaryReportExists(string id)
        {
            return _context.SalaryReports.Any(e => e.PAN == id);
        }
    }
}
