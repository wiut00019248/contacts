using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.CW._19248.Data;
using Web.CW._19248.Dtos;
using Web.CW._19248.Models;
using Web.CW._19248.Repositories;

namespace Web.CW._19248.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IRepository<Contact> _repository;
        private readonly IMapper _mapper;

        public ContactController(IRepository<Contact> repository, IMapper mapper)
        { 
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/Contact
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var contacts = await _repository.GetAllAsync();
            var contactsDto = _mapper.Map<IEnumerable<ContactDto>>(contacts);
            return Ok(contactsDto);
        }

        // GET: api/Contact/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Contact), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetContact(int id)
        {
            var contact = await _repository.GetAsync(id);
            if (contact == null)
            {
                return NotFound();
            }
            var contactDto = _mapper.Map<ContactDto>(contact);
            return Ok(contactDto);
        }

        // POST: api/Contact
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateContact(ContactDto contactDto)
        {
            var contact = _mapper.Map<Contact>(contactDto);
            await _repository.CreateAsync(contact);
            return Ok(contact);
        }

        // PUT: api/Contact/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateContact(ContactDto contactDto)
        {
            var contact = _mapper.Map<Contact>(contactDto);
            await _repository.UpdateAsync(contact);
            return NoContent();
        }

        // DELETE: api/Contact/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var contact = await _repository.GetAsync(id);
            if (contact == null)
            {
                return NotFound();
            }
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
