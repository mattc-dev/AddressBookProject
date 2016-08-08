using AddressBook.Models;
using System.Collections.Generic;

namespace AddressBook.DAL
{
    public interface IDataAccess
    {
        IEnumerable<ContactModel> GetAll();

        ContactModel GetById(int id);

        void Edit(ContactModel contact);

        void Delete(int id);

        void Insert(ContactModel contact);
    }
}