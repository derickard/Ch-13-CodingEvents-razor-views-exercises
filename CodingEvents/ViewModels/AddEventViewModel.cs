using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEvents.ViewModels
{
    public class AddEventViewModel
    {
        [Required, StringLength(50, MinimumLength =3, ErrorMessage = "Event names between 3 and 50 characters.")]
        public string Name { get; set; }

        [StringLength(500, ErrorMessage = "Max description length 500 characters.")]
        public string Description { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email.")]
        public string ContactEmail { get; set; }
    }
}
