using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using AdventurousContacts.Models;
using AdventurousContacts.Models.Repository;
using AdventurousContacts.ViewModels;
using AdventurousContacts.Resources;

namespace AdventurousContacts.Controllers
{
    public class ContactController : Controller
    {
        // Object conatining CRUD-functionality for contacts.
        private IRepository _repository;

        public ContactController()
            : this(new Repository())
        {
            // Empty
        }

        // Initialize fields.
        public ContactController(IRepository repository)
        {
            _repository = repository;
        }


        //
        // GET: /Contact/
        // Displays startpage with contacts.
        public ActionResult Index()
        {
            return View("Index", _repository.GetLastContacts());
        }

        //
        // GET: /Contact/Create
        // Displays create form.
        public ActionResult Create()
        {
            return View("Create");
        }

        //
        // POST: /Contact/Create
        // Saves contact created by user.
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

        //
        // GET: /Contact/Edit
        // Display editable contact. 
        public ActionResult Edit(int id = 0)
        {
            var contact = _repository.GetContactById(id);
            if (contact == null)
            {
                return View("NotFound");
            }

            return View("Edit", contact);
        }

        //
        // POST: /Contact/Edit
        // Updates contact with input from user.
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
            catch (Exception exception)
            {
                ModelState.AddModelError(String.Empty, exception.GetBaseException().Message);
            }

            return View("Edit", contact);
        }

        //
        // GET: /Contact/Delete
        // Asks user for delete confirmation.
        public ActionResult Delete(int id = 0)
        { 
            var contact = _repository.GetContactById(id);
            if (contact == null)
            {
                return View("NotFound");
            }

            return View("Delete", contact);
        }

        //
        // POST: /Contact/Delete
        // Delets contact
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

        // Writes unhandle exception to logfile 
        protected override void OnException(ExceptionContext filterContext)
        {
            StringBuilder errorMessage = new StringBuilder();
            errorMessage.AppendLine(DateTime.Now.ToString());
            errorMessage.AppendLine(filterContext.Exception.ToString());
            errorMessage.AppendLine(Strings.LogDivider);

            FileStream fileStream = new FileStream(Server.MapPath("App_Data/LogFile.txt"), FileMode.Append, FileAccess.Write);
            StreamWriter streamWriter = new StreamWriter(fileStream);
            streamWriter.Write(errorMessage.ToString());
            streamWriter.Close();
        }
    }
}
