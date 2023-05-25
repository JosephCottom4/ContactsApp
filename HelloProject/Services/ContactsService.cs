using ContactsAppCore.Models;
using ContactsAppCore.Repositories;

namespace ContactsAppCore.Services
{
    public class ContactsService : IContactsService
    {
        private readonly IContactsRepository _contactsRepository;

        public ContactsService(IContactsRepository contactsRepository)
        {
            _contactsRepository = contactsRepository;
        }

        public async Task<List<Contact>> GetAllContacts()
        {
            return await _contactsRepository.GetAllContacts();
        }

        public async Task<Contact> GetContact(int id)
        {
            return await _contactsRepository.GetContact(id);
        }

        public async Task DeleteContact(int id)
        {
            await _contactsRepository.DeleteContact(id);
        }

        public async Task CreateContact(NewContactDto contact)
        {
            ValidateContact(contact);

            await _contactsRepository.CreateContact(contact);
        }

        public async Task UpdateContact(UpdateContactDto contact)
        {
            ValidateContact(contact);

            await _contactsRepository.UpdateContact(contact);
        }

        private static void ValidateContact(NewContactDto contact)
        {
            if (string.IsNullOrWhiteSpace(contact.FirstName)) throw new InvalidDataException("First Name cannot be blank");

            if (string.IsNullOrWhiteSpace(contact.LastName)) throw new InvalidDataException("First Name cannot be blank");

            if (string.IsNullOrWhiteSpace(contact.PhoneNumber)) throw new InvalidDataException("Phone Number cannot be blank");

            if (!contact.FirstName.All(char.IsLetter)) throw new InvalidDataException("First Name must contain only letters");

            if (!contact.LastName.All(char.IsLetter)) throw new InvalidDataException("Last Name must contain only letters");

            if (!contact.PhoneNumber.All(char.IsNumber)) throw new InvalidDataException("Phone Number must contain only numbers");
        }
    }
}
