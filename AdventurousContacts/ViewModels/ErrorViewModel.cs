using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdventurousContacts.ViewModels
{
    public class ErrorViewModel
    {
        private string _title;
        private string _message;

        public string Title
        {
            get
            {
                return _title;
            }
        }

        public string Message
        {
            get
            {
                return _message;
            }
        }

        public ErrorViewModel(string title, string message)
        {
            _title = title;
            _message = message;
        }
    }
}