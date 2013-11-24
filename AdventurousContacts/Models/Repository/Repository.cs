using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using AdventurousContacts.Models.DataModels;

namespace AdventurousContacts.Models.Repository
{
    public class Repository
    {
        private bool _disposed = false;

        private AdventureWorksAssignmentEntities _entites = new AdventureWorksAssignmentEntities();


        public void Add(Contact contact)
        {
            _entites.Contacts.Add(contact);
        }

        public void Delete(Contact contact)
        {
            _entites.Contacts.Remove(contact);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _entites.Dispose();
                }
                _disposed = true;
            }
        }

        public IQueryable<Contact> FindAllContacts()
        {
            return _entites.Contacts;
        }

        public Contact GetContactById(int contactId)
        {
            return _entites.Contacts.Find(contactId);
        }

        public List<Contact> GetLastContacts(int count)
        {
            return _entites.Contacts.Take(count).ToList();
        }

        public void Save()
        {
            _entites.SaveChanges();
        }

        public void Update(Contact contact)
        {
            _entites.Entry(contact).State = EntityState.Modified;
        }


    }
}