using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.CW._19248.Data;
using Web.CW._19248.DTOs;
using Web.CW._19248.Models;
using Web.CW._19248.Repositories;

namespace Web.CW._19248.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IRepository<Contact> _contactRepo;
        private readonly IRepository<Category> _catRepo;
        private readonly IMapper _mapper;


        public ContactController(
            IRepository<Contact> contactRepo,
            IRepository<Category> catRepo,
            IMapper mapper)
        {
            _contactRepo = contactRepo;
            _catRepo = catRepo;
            _mapper = mapper;
        }

        // GET: api/Contact
        [HttpGet]
        public async Task<IActionResult> GetContactDatabase()
        {
            var contacts = await _contactRepo.GetAllAsync();
            var contactDtos = _mapper.Map<IEnumerable<ContactDto>>(contacts);
            return Ok(contactDtos);
        }

        // GET: api/Contact/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContact(int id)
        {
            var contacts = await _contactRepo.GetAsync(id);
            if (contacts == null)
            {
                return NotFound();
            }
            var contactDtos = _mapper.Map<ContactDto>(contacts);
            return Ok(contactDtos);
        }

        // PUT: api/Contact/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContact(int id, ContactDto contactDto)
        {
            if (id != contactDto.Id)
            {
                return BadRequest();
            }
            var contact = _mapper.Map<Contact>(contactDto);
            await _contactRepo.UpdateAsync(contact);
            return NoContent();
        }

        // POST: api/Contact
        [HttpPost]
        public async Task<IActionResult> CreateContact(ContactDto contactDto)
        {
            var contact = _mapper.Map<Contact>(contactDto);
            await _contactRepo.CreateAsync(contact);
            var newContact = _mapper.Map<ContactDto>(contact);
            return CreatedAtAction(nameof(GetContact), new { id = newContact.Id }, newContact);
        }

        // DELETE: api/Contact/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var contact = await _contactRepo.GetAsync(id);
            if (contact == null)
            {
                return NotFound();
            }
            await _contactRepo.DeleteAsync(id);
            return NoContent();
        }
    }
}
