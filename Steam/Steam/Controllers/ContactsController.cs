using STEAM.Services;
using Microsoft.AspNetCore.Mvc;
using STEAM.Models.Contacts;

namespace STEAM.Controllers
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

        [HttpGet("list/{newContacts}")]
        public async Task<List<GetContactDTO>> GetContacts(bool newContacts)
        {
            return await _contactsService.GetContacts(newContacts);
        }

        [HttpGet("{id}")]
        public async Task<GetContactDTO?> GetContact(int id)
        {
            return await _contactsService.GetContact(id);
        }

        [HttpPost]
        public async Task PostContact(AddContactDTO contact)
        {
            await _contactsService.AddContact(contact);
        }

        [HttpPut]
        public async Task PutContact(UpdateContactDTO contact)
        {
            await _contactsService.UpdateContact(contact);
        }
    }
}