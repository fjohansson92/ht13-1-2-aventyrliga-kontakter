using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdventurousContacts.Models;
using AdventurousContacts.Models.Repository;
using AdventurousContacts.ViewModels;

namespace AdventurousContacts.Controllers
{
    public class ContactController : Controller
    {
        private IRepository _repository;

        public ContactController()
            : this(new Repository())
        {
            // Empty
        }

        public ContactController(IRepository repository)
        {
            _repository = repository;
        }


        //
        // GET: /Contact/

        public ActionResult Index()
        {
            return View("Index", _repository.GetLastContacts());
        }

        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="EmailAddress, FirstName, LastName")]Contact contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _repository.Add(contact);
                    _repository.Save();

                    var model = new SuccessViewModel(contact);
                    return View("Success", model);
                }
                catch(Exception exception)
                {
                    ModelState.AddModelError(String.Empty, exception.InnerException.Message);
                }
            }
            return View("Create", contact);
        }

        public ActionResult Edit(int id = 0)
        {
            var contact = _repository.GetContactById(id);
            if (contact == null)
            {
                return View("NotFound");
            }

            return View("Edit", contact);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Contact contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repository.Update(contact);
                    _repository.Save();

                    var model = new SuccessViewModel(contact);
                    return View("Success", model);
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty,
                    "Error message");
            }

            return View("Edit", contact);
        }


        public ActionResult Delete(int id = 0)
        { 
            var contact = _repository.GetContactById(id);
            if (contact == null)
            {
                return View("NotFound");
            }

            return View("Delete", contact);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var contact = _repository.GetContactById(id);
            try
            {
                _repository.Delete(contact);
                _repository.Save();

                var model = new SuccessViewModel(contact);
                return View("Success", model);
            }
            catch (Exception exception)
            {
                ModelState.AddModelError(String.Empty, exception.GetBaseException().Message);
            }
            
            return View("Delete", contact);
        }
    }
}
