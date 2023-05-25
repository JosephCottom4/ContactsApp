using HelloProject.Models;
using HelloProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace HelloProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly IContactsService _contactsService;

        public ContactsController(IContactsService contactsService)
        {
            _contactsService = contactsService;
        }

        [HttpGet("all")]
        public async Task<IEnumerable<Contact>> Get()
        {
            var results = await _contactsService.GetAllContacts();

            return results;
        }

        [HttpGet("{id}")]
        public async Task<Contact> Get([FromRoute] int id)
        {
            var results = await _contactsService.GetContact(id);

            return results;
        }

        [HttpDelete("{id}")]
        public async Task Delete([FromRoute] int id)
        {
            await _contactsService.DeleteContact(id);
        }

        [HttpPost]
        public async Task Create([FromBody] NewContactDto newContact)
        {
            await _contactsService.CreateContact(newContact);
        }

        [HttpPut]
        public async Task Update([FromBody] UpdateContactDto updateContact)
        {
            await _contactsService.UpdateContact(updateContact);
        }
    }
}