using AddressBook.DAL;
using AddressBook.Models;
using System.Net;
using System.Web.Mvc;

namespace AddressBook.Controllers
{
    public class ContactController : Controller
    {
        private readonly IDataAccess _dbCall = DependencyResolver.Current.GetService<IDataAccess>();

        public ActionResult Index()
        {
            ViewBag.Message = "Home Page";

            return View();
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Message = "Edit Contact";

            var contact = _dbCall.GetById(id);

            return View(contact);
        }

        [HttpPost]
        public ActionResult Edit(ContactModel contact)
        {
            ViewBag.Message = "Edit Contact";

            if (ModelState.IsValid)
            {
                _dbCall.Edit(contact);
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(ContactModel contact)
        {
            ViewBag.Message = "Add Contact";

            if (ModelState.IsValid)
            {
                _dbCall.Insert(contact);
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Remove(int id)
        {
            var contact = _dbCall.GetById(id);

            if (contact == null)
            {
                return HttpNotFound();
            }

            _dbCall.Delete(id);

            return RedirectToAction("Index");
        }

    }
}