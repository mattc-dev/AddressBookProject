using System;
using AddressBook.Models;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Web;

namespace AddressBook.DAL
{
    public class DataAccessImpl : IDataAccess
    {
        readonly string filePath = HttpContext.Current.Server.MapPath("~/App_Data/Contacts.json");

        public IEnumerable<ContactModel> GetAll()
        {
            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                List<ContactModel> contacts = JsonConvert.DeserializeObject<List<ContactModel>>(json);

                return contacts;
            }
        }

        public ContactModel GetById(int id)
        {
            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                List<ContactModel> contacts = JsonConvert.DeserializeObject<List<ContactModel>>(json);
                return contacts.Find(p => p.ID == id);
            }
        }
        
        public void Insert(ContactModel contact)
        {
            string updates = string.Empty;

            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                List<ContactModel> contacts = JsonConvert.DeserializeObject<List<ContactModel>>(json);

                //lets get the latest ID and add 1
                contacts.Sort((x, y) => x.ID.CompareTo(y.ID));
                var lastContact = contacts[contacts.Count - 1];
                contact.ID = lastContact.ID + 1;

                contacts.Add(contact);
                updates = JsonConvert.SerializeObject(contacts);
            }

            //add the new contact
            if(!String.IsNullOrEmpty(updates))
            {
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    sw.Write(updates);
                }
            }
        }

        public void Edit(ContactModel contact)
        {
            string edits = string.Empty;

            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                List<ContactModel> contacts = JsonConvert.DeserializeObject<List<ContactModel>>(json);

                //update the contact
                contacts.Remove(contacts.Find(p => p.ID == contact.ID));
                contacts.Add(contact);

                edits = JsonConvert.SerializeObject(contacts);
            }

            if (!String.IsNullOrEmpty(edits))
            {
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    sw.Write(edits);
                }
            }
        }

        public void Delete(int id)
        {
            string removed = string.Empty;

            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                List<ContactModel> contacts = JsonConvert.DeserializeObject<List<ContactModel>>(json);

                //update the contact
                contacts.Remove(contacts.Find(p => p.ID == id));
                removed = JsonConvert.SerializeObject(contacts);
            }

            if (!String.IsNullOrEmpty(removed))
            {
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    sw.Write(removed);
                }
            }
        }
    }
}
