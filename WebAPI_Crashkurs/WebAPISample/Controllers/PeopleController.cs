using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPISample.Data;
using WebAPISample.Models;

namespace WebAPISample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly PersonDBContext _context;

        public PeopleController(PersonDBContext context)
        {
            _context = context;


            if (!_context.Persons.Any())
            {
                _context.Persons.Add(new Person { Id = 1, FirstName = "Peter", LastName = "Mustermann" });
                _context.Persons.Add(new Person { Id = 2, FirstName = "Petra", LastName = "Musterfrau " });
            }
            _context.SaveChanges();
        }


        // [Get-Methode] [GetPersons] -> URL Call -> https://localhost:12345/api/People
        // [Get-Methode] [GetPerson] -> URL Call -> https://localhost:12345/api/People/5

        // [HttpPut] [PutPerson] ->: URL Call -> https://localhost:12345/api/People/5
        // [HttpPost] [PostPerson] -> URL Call -> https://localhost:12345/api/People 

        // [HttpDelete] [DeletePerson] -> URL Call -> https://localhost:12345/api/People/5

        // GET: api/People
        [HttpGet] //Http sagt expliziet aus - um welche HTTP Methode
        public async Task<ActionResult<IEnumerable<Person>>> GetPersons()
        {

            
            return await _context.Persons.ToListAsync();
        }

        // GET: api/People/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            var person = await _context.Persons.FindAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            return person;
        }

        // PUT: api/People/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson(int id, Person person)
        {
            if (id != person.Id)
            {
                return BadRequest();
            }

            _context.Entry(person).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
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

        // POST: api/People
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson(Person person)
        {
            _context.Persons.Add(person);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPerson", new { id = person.Id }, person);
        }

        // DELETE: api/People/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            var person = await _context.Persons.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonExists(int id)
        {
            return _context.Persons.Any(e => e.Id == id);
        }
    }
}
