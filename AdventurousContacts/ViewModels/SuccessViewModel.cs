using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AdventurousContacts.Models;

namespace AdventurousContacts.ViewModels
{
    public class SuccessViewModel
    {
        public Contact _contact;

        public SuccessViewModel(Contact contact)
        {
            _contact = contact;
        }

        public string ContactInfo
        {
            get
            {
                return String.Format("{0} {1} ({2})", _contact.FirstName, _contact.LastName, _contact.EmailAddress);
            }
        }

        public string GetSuccessMessage(object p)
        {
            string message = "";
            try
            {
                if (p.Equals("Create"))
                {
                    message = " was successfully created.";
                }
                else if (p.Equals("Delete"))
                {
                    message = " was successfully deleted.";
                }
                else
                {
                    message = " was successfully saved.";
                }
            }
            catch (Exception) {}

            return message;
        }
    }
}