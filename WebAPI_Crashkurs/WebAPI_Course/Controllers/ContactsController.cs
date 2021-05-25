using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_Course.Models;

namespace WebAPI_Course.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private static readonly ConcurrentDictionary<string, Contact> _contacts =
            new ConcurrentDictionary<string, Contact>();

        public ContactsController()
        {
            if (_contacts.Count == 0)
                Add(new Contact { FirstName = "Tester", LastName = "Muster" });

        }

        [HttpGet]
        public IEnumerable<Contact> Get()
        {
            return _contacts.Values;
        }

        [HttpPost]
        public IActionResult Post ([FromBody] Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Add(contact);


            return CreatedAtAction(nameof(Get), new { id = contact.Id }, contact);
        }

        private void Add(Contact contact)
        {
            contact.Id = Guid.NewGuid().ToString();
            _contacts[contact.Id] = contact;
        }

    }
}
