using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdventurousContacts.ViewModels;

namespace AdventurousContacts.Controllers
{
    public class ErrorController : Controller
    {

        public ActionResult Index()
        {
            ErrorViewModel model = new ErrorViewModel("Error", "Sorry, an error occurred while processing your request.");

            return View("Error", model);
        }

        public ActionResult NotFound()
        {
            ErrorViewModel model = new ErrorViewModel("Error 404", "Ooops! Server returned a 404 (page not found)! In English it means the page, address, url you are looking for has moved without leaving a forwarding address!");

            return View("Error", model);
        }

    }
}
