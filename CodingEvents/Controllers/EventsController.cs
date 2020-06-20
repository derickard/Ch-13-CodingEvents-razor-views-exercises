using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using CodingEvents.Data;
using CodingEvents.Models;
using CodingEvents.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CodingEvents.Controllers
{
    public class EventsController : Controller
    {

        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            List<Event> events = new List<Event>(EventData.GetAll());
            return View(events);
        }

        [HttpGet]
        public IActionResult Add()
        {
            AddEventViewModel addEventViewModel = new AddEventViewModel();
            return View(addEventViewModel);
        }

        [HttpPost("/Events/Add")]
        public IActionResult NewEvent([Bind("Name,Description,ContactEmail,Location,NumberAttendees,MustRegister")] AddEventViewModel addEventViewModel)
        {
            if(ModelState.IsValid)
            {
                Event newEvent = new Event(addEventViewModel.Name, addEventViewModel.Description, addEventViewModel.ContactEmail, addEventViewModel.Location, addEventViewModel.NumberAttendees, addEventViewModel.MustRegister);
                EventData.Add(newEvent);

                return Redirect("/Events");
            }
            return View("Add", addEventViewModel);
        }

        public IActionResult Delete()
        {
            ViewBag.events = EventData.GetAll();

            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] eventIds)
        {
            foreach(int eventId in eventIds)
            {
                EventData.Remove(eventId);
            }

            return Redirect("/Events");
        }

        [HttpGet]
        [Route("/Events/Edit/{eventId}")]
        public IActionResult Edit(int eventId)
        {
            ViewBag.title = $"Edit Event {EventData.GetById(eventId).Name} (id={EventData.GetById(eventId).Id})";
            ViewBag.editEvent = EventData.GetById(eventId);
            return View();
        }

        [HttpPost("/Events/Edit")]
        public IActionResult SubmittedEditEventForm(int eventId, string name, string description)
        {
            EventData.GetById(eventId).Name = name;
            EventData.GetById(eventId).Description = description;
            return Redirect("/Events");
        }
    }
}
