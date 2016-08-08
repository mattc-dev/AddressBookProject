using AddressBook.DAL;
using AddressBook.Models;
using System.Web.Http;
using System.Web.Mvc;

namespace AddressBook.Controllers
{
    public class DataController : ApiController
    {

        private readonly IDataAccess _dbCall = DependencyResolver.Current.GetService<IDataAccess>();

        // Get
        public IHttpActionResult GetAll()
        {
            var dataTable = new { data = _dbCall.GetAll() };
            return Json(dataTable);
        }

        // Get by ID
        public IHttpActionResult GetById(int id)
        {
            var dataTable = new { data = _dbCall.GetById(id) };
            return Json(dataTable);
        }


        // Insert
        public IHttpActionResult Post([FromBody] ContactModel contact)
        {
            if (contact == null)
            {
                return BadRequest("Invalid passed data");
            }

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }            

            _dbCall.Insert(contact);

            //just give me back the contact you gave me
            return Json(contact);
        }

        // Update
        public IHttpActionResult Put([FromBody] ContactModel contact)
        {
            if (contact == null)
            {
                return BadRequest("Invalid passed data");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _dbCall.Edit(contact);

            return Json(contact);
        }

        // Delete
        [System.Web.Http.HttpGet]
        public IHttpActionResult Delete(int id)
        {
            _dbCall.Delete(id);

            return Ok();
        }
    }
}
