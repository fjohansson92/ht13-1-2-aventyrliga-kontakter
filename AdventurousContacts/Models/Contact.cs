using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using AdventurousContacts.Resources;

namespace AdventurousContacts.Models
{
    [MetadataType(typeof(Contact_Metadata))]
    public partial class Contact
    {
        public class Contact_Metadata
        {
            // Email address for contact
            [Required]
            [EmailAddress]
            [Display(Name = "EmailName", ResourceType = typeof(Resources.Strings))]
            public string EmailAddress { get; set; }

            // First name for contact
            [Required]
            [StringLength(50)]
            [Display(Name = "FirstName", ResourceType = typeof(Resources.Strings))]
            public string FirstName { get; set; }

            // Last name for contact
            [Required]
            [StringLength(50)]
            [Display(Name = "LastName", ResourceType = typeof(Resources.Strings))]
            public string LastName { get; set; }
        }
    }
}