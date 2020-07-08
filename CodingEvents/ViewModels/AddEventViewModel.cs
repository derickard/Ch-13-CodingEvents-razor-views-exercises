using CodingEvents.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        [Required]
        public string Location { get; set; }

        [Range(0,100000, ErrorMessage = "Attendance between 0 and 100,000")]
        public int NumberAttendees { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public int CategoryId { get; set; }
        public List<SelectListItem> Categories { get; set; }

        public AddEventViewModel()
        {
        }

        public AddEventViewModel(List<EventCategory> categories)
        {
            Categories = new List<SelectListItem>();

            foreach(var category in categories)
            {
                Categories.Add(new SelectListItem
                {
                    Value = category.Id.ToString(),
                    Text = category.Name
                });
            }
        }

        public bool IsTrue { get { return true; } }

        [Compare(nameof(IsTrue), ErrorMessage = "You must register.")]
        public bool MustRegister { get; set; }
    }
}
