using System;
using System.ComponentModel.DataAnnotations;

namespace AddressBook.Models
{
    public class ContactModel
    {
        public int ID { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string Address { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string City { get; set; }

        [Required]
        [StringLength(2, ErrorMessage = "The {0} must be {2} characters long.", MinimumLength = 2)]
        public string State { get; set; }
    }
}