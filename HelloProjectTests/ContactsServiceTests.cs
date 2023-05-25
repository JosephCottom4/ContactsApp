using ContactsAppCore.Models;
using ContactsAppCore.Repositories;
using ContactsAppCore.Services;
using Moq;

namespace ContactsAppTests
{
    public class ContactsServiceTests
    {
        private readonly Mock<IContactsRepository> _contactsRepository;
        private readonly IContactsService _contactsService;

        public ContactsServiceTests()
        {
            _contactsRepository = new Mock<IContactsRepository>();

            _contactsService = new ContactsService(_contactsRepository.Object);
        }

        [Fact]
        public void Create_WithValidData_CallsRepo()
        {
            var contact = new NewContactDto
            {
                FirstName = "Joseph",
                LastName = "Cottom",
                PhoneNumber = "07847220632"
            };

            _contactsService.CreateContact(contact);

            _contactsRepository.Verify(x => x.CreateContact(contact), Times.Once);
        }

        [Fact]
        public async Task Create_WithFirstNameWithNumbers_ThrowsException()
        {
            var contact = new NewContactDto
            {
                FirstName = "Jos545eph",
                LastName = "Cottom",
                PhoneNumber = "07847220632"
            };

            await Assert.ThrowsAsync<InvalidDataException>(() => _contactsService.CreateContact(contact));
        }

        [Fact]
        public async Task Create_WithLastNameWithNumbers_ThrowsException()
        {
            var contact = new NewContactDto
            {
                FirstName = "Joseph",
                LastName = "Cot574tom",
                PhoneNumber = "07847220632"
            };

            await Assert.ThrowsAsync<InvalidDataException>(() => _contactsService.CreateContact(contact));
        }

        [Fact]
        public async Task Create_WithPhoneWithLetters_ThrowsException()
        {
            var contact = new NewContactDto
            {
                FirstName = "Joseph",
                LastName = "Cottom",
                PhoneNumber = "0784dfgdfg7220632"
            };

            await Assert.ThrowsAsync<InvalidDataException>(() => _contactsService.CreateContact(contact));
        }

        [Fact]
        public async Task Create_WithBlankFirstName_ThrowsException()
        {
            var contact = new NewContactDto
            {
                FirstName = "",
                LastName = "Cottom",
                PhoneNumber = "0784dfgdfg7220632"
            };

            await Assert.ThrowsAsync<InvalidDataException>(() => _contactsService.CreateContact(contact));
        }

        [Fact]
        public async Task Create_WithBlankLastName_ThrowsException()
        {
            var contact = new NewContactDto
            {
                FirstName = "Joseph",
                LastName = "   ",
                PhoneNumber = "0784dfgdfg7220632"
            };

            await Assert.ThrowsAsync<InvalidDataException>(() => _contactsService.CreateContact(contact));
        }

        [Fact]
        public async Task Create_WithBlankPhone_ThrowsException()
        {
            var contact = new NewContactDto
            {
                FirstName = "Joseph",
                LastName = "Cottom",
                PhoneNumber = ""
            };

            await Assert.ThrowsAsync<InvalidDataException>(() => _contactsService.CreateContact(contact));
        }
    }
}