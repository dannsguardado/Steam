using STEAM.Database;
using STEAM.Database.Entities;
using Microsoft.EntityFrameworkCore;
using STEAM.Models.Contacts;
using STEAM.Database.Enums;
using AutoMapper;

namespace STEAM.Services
{
    public interface IContactsService
    {
        Task<List<GetContactDTO>> GetContacts(bool newContacts);
        Task<GetContactDTO?> GetContact(int id);
        Task AddContact(AddContactDTO contact);
        Task UpdateContact(UpdateContactDTO contact);
    }

    public class ContactsService : IContactsService
    {
        private readonly DatabaseContext _dbContext;
        private readonly IMapper _mapper;

        public ContactsService(DatabaseContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<GetContactDTO>> GetContacts(bool newContacts)
        {
            var query = _dbContext.Contacts.AsSplitQuery();

            if(newContacts)
            {
                query = query.Where(x => x.Status == ContactStatus.New);
            }
            
            var result = await query.ToListAsync();

            return result.Select(x => _mapper.Map<GetContactDTO>(x)).ToList();
        }

        public async Task<GetContactDTO?> GetContact(int id)
        {
            var resultEntity = await _dbContext.Contacts.FirstOrDefaultAsync(x => x.Id == id);

            var result = _mapper.Map<GetContactDTO>(resultEntity);
            
            if(resultEntity is not null && resultEntity.Status == ContactStatus.New)
            {
                resultEntity.Status = ContactStatus.Seen;
                await _dbContext.SaveChangesAsync();
            }

            return result;
        }

        public async Task AddContact(AddContactDTO contact)
        {
            var entity = _mapper.Map<Contact>(contact);

            entity.Status = ContactStatus.New;

            await _dbContext.Contacts.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateContact(UpdateContactDTO contact)
        {
            var entity = await _dbContext.Contacts.FirstOrDefaultAsync(x => x.Id == contact.Id);

            if (entity == null)
            {
                return;
            }
            _mapper.Map(contact, entity);

            await _dbContext.SaveChangesAsync();
        }
    }
}
