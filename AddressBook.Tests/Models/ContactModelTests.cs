using AddressBook.Models;
using NUnit.Framework;

namespace AddressBook.Controllers.Tests
{
    [TestFixture]
    public class ContactModelsTests
    {
        [Test]
        public void Edit_ContactModel_Test()
        {
            var expectedContact = new ContactModel
            {
                ID = 1,
                Address = "123 test",
                City = "Dallas",
                State = "TX"
            };

            Assert.NotNull(expectedContact);
            Assert.AreSame(expectedContact.Address, "123 test");
            Assert.AreSame(expectedContact.City, "Dallas");
            Assert.AreSame(expectedContact.State, "TX");
        }
    }
}