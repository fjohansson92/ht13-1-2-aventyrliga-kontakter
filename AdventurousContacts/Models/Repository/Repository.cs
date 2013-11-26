using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using AdventurousContacts.Models.DataModels;

namespace AdventurousContacts.Models.Repository
{
    public class Repository : IRepository
    {
        // If databaseconnection has been disposed.
        private bool _disposed = false;

        // 
        private AdventureWorksAssignmentEntities _entites = new AdventureWorksAssignmentEntities();

        // Adds contact to database
        public void Add(Contact contact)
        {
            _entites.Contacts.Add(contact);
        }

        // Removes contact from database
        public void Delete(Contact contact)
        {
            _entites.Contacts.Remove(contact);
        }

        // Implements IDisposable
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Disposes the databaseconnection.
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

        // Gets all contacts in database.
        public IQueryable<Contact> FindAllContacts()
        {
            return _entites.Contacts;
        }

        // Get contact from database.
        public Contact GetContactById(int contactId)
        {
            return _entites.Contacts.Find(contactId);
        }

        // Gets the latest added contacts in database.
        public List<Contact> GetLastContacts(int count)
        {
            var contacts = _entites.Contacts;
            return contacts.AsEnumerable().Skip(Math.Max(0, contacts.Count()) - count).Take(count).Reverse().ToList();
            //return _entites.Contacts.AsEnumerable().Reverse().Take(count).ToList();
        }

        // Saves changes to database.
        public void Save()
        {
            _entites.SaveChanges();
        }

        // Updates a existent contact in database.
        public void Update(Contact contact)
        {
            _entites.Entry(contact).State = EntityState.Modified;
        }


    }
}