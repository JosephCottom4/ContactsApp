using HelloProject.Models;

namespace HelloProject.Services
{
    public interface IContactsService
    {
        Task<List<Contact>> GetAllContacts();

        Task<Contact> GetContact(int id);

        Task DeleteContact(int id);

        Task CreateContact(NewContactDto contact);

        Task UpdateContact(UpdateContactDto contact);
    }
}
