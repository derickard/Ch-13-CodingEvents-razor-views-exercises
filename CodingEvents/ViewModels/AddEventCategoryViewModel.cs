using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEvents.ViewModels
{
    public class AddEventCategoryViewModel
    {
        [Required, StringLength(20, MinimumLength = 3, ErrorMessage = "Between 3 and 20 characters.")]
        public string Name { get; set; }
    }
}
