using Dapper;
using HelloProject.Models;
using System.Data;

namespace HelloProject.Repositories
{
    public class ContactsRepository : IContactsRepository
    {
        private readonly IDbConnection _connection;

        public ContactsRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<List<Contact>> GetAllContacts()
        {
            SqlMapper.AddTypeMap(typeof(DateTime), System.Data.DbType.DateTime2);

            var result = await _connection.QueryAsync<Contact>("[dbo].[GetAllContacts]",
                commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public async Task<Contact> GetContact(int id)
        {
            var queryParams = new { Id = id };

            var result = await _connection.QuerySingleAsync<Contact>("[dbo].[GetContact]", queryParams,
                commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task DeleteContact(int id)
        {
            var queryParams = new { Id = id };

            await _connection.ExecuteAsync("[dbo].[DeleteContact]", queryParams,
                commandType: CommandType.StoredProcedure);
        }

        public async Task CreateContact(NewContactDto contact)
        {
            var queryParams = new { contact.FirstName, contact.LastName, contact.PhoneNumber };

            await _connection.ExecuteAsync("[dbo].[CreateContact]", queryParams,
                commandType: CommandType.StoredProcedure);
        }

        public async Task UpdateContact(UpdateContactDto contact)
        {
            var queryParams = new { contact.Id, contact.FirstName, contact.LastName, contact.PhoneNumber, };

            await _connection.ExecuteAsync("[dbo].[UpdateContact]", queryParams,
                commandType: CommandType.StoredProcedure);
        }
    }
}
