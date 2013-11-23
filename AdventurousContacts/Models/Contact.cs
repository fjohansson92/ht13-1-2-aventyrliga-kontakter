using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdventurousContacts.Models
{
    [MetadataType(typeof(Contact_Metadata))]
    public partial class Contact
    {
        public class Contact_Metadata
        {
            //TODO: Add validation
            public string EmailAdress { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
    }
}