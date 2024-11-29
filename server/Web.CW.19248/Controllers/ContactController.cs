using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.CW._19248.Data;
using Web.CW._19248.Models;
using Web.CW._19248.Repositories;

namespace Web.CW._19248.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IRepository<Contact> _repo;

        public ContactController(IRepository<Contact> repo)
        { 
            _repo = repo;
        }

        // GET: api/Contact
        [HttpGet]
        public async Task<IEnumerable<Contact>> GetContactDatabase()
        {
            return await _repo.GetAllAsync();
        }

        // GET: api/Contact/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Contact), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetContact(int id)
        {
            var contact = await _repo.GetAsync(id);
            return contact == null ? NotFound() : Ok(contact);
        }

        // PUT: api/Contact/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateContact(Contact contact)
        {
            await _repo.UpdateAsync(contact);
            return NoContent();
        }

        // POST: api/Contact
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateContact(Contact contact)
        {
            await _repo.CreateAsync(contact);
            return Ok(contact);
        }

        // DELETE: api/Contact/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteContact(int id)
        {
            await _repo.DeleteAsync(id);
            return NoContent();
        }
    }
}
