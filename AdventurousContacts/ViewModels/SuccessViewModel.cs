using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AdventurousContacts.Models;
using AdventurousContacts.Resources;

namespace AdventurousContacts.ViewModels
{
    public class SuccessViewModel
    {
        // Saved contact
        public Contact _contact;

        public SuccessViewModel(Contact contact)
        {
            _contact = contact;
        }

        // Returns contact information
        public string ContactInfo
        {
            get
            {
                return String.Format(Strings.ContactFormation, _contact.FirstName, _contact.LastName, _contact.EmailAddress);
            }
        }

        // Returns success message.
        public string GetSuccessMessage(object p)
        {
            string message = "";
            try
            {
                if (p.Equals(Strings.Create))
                {
                    message = Strings.CreateSuccess;
                }
                else if (p.Equals(Strings.Delete))
                {
                    message = Strings.DeleteSuccess;
                }
                else
                {
                    message = Strings.SavedSuccess;
                }
            }
            catch (Exception) {}

            return message;
        }
    }
}