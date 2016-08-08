using System.Web.Mvc;
using NUnit.Framework;
using AddressBook.Controllers;
using AddressBook.DAL;

namespace AddressBook.Tests.Controllers
{
    [TestFixture]
    public class ContactControllerTest
    {
        
        [Test]
        public void IndexTest()
        {
            ContactController controller = new ContactController();

            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
        }

        [Test]
        public void IndexViewBagMessageTest()
        {
            ContactController controller = new ContactController();

            ViewResult result = controller.Index() as ViewResult;

            Assert.AreEqual("Home Page", result.ViewBag.Message);
        }

        [Test]
        public void EditTest()
        {
            ContactController controller = new ContactController();

            var dbCall = new DataAccessImpl();
            var c = dbCall.GetById(2);

            ViewResult result = controller.Edit(2) as ViewResult;

            Assert.AreEqual("Edit", result.ViewName);
        }
    }
}
