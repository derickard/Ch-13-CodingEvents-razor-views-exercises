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

        public EventType Type { get; set; }

        public List<SelectListItem> EventTypes { get; set; }

        public AddEventViewModel()
        {
            EventTypes = new List<SelectListItem>();

            EventTypes.Add(new SelectListItem
            {
                Value = EventType.CONFERENCE.ToString(),
                Text = EventType.CONFERENCE.ToString()
            });

            EventTypes.Add(new SelectListItem
            {
                Value = EventType.MEETUP.ToString(),
                Text = EventType.MEETUP.ToString()
            });

            EventTypes.Add(new SelectListItem
            {
                Value = EventType.SOCIAL.ToString(),
                Text = EventType.SOCIAL.ToString()
            });

            EventTypes.Add(new SelectListItem
            {
                Value = EventType.WORKSHOP.ToString(),
                Text = EventType.WORKSHOP.ToString()
            });
        }

        public bool IsTrue { get { return true; } }

        [Compare(nameof(IsTrue), ErrorMessage = "You must register.")]
        public bool MustRegister { get; set; }
    }
}
