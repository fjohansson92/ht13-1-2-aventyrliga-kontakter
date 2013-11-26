using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdventurousContacts.ViewModels;
using AdventurousContacts.Resources;

namespace AdventurousContacts.Controllers
{
    public class ErrorController : Controller
    {
        // Present error page on unhandle exceptions.
        public ActionResult Index()
        {
            ErrorViewModel model = new ErrorViewModel(Strings.ErrorTitle, Strings.UnexpectedError);

            return View("Error", model);
        }

        // Presents error page on page not found errors.
        public ActionResult NotFound()
        {
            ErrorViewModel model = new ErrorViewModel(Strings.ErrorTitle, Strings.PageNotFoundError);

            return View("Error", model);
        }

    }
}
