using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using CodingEvents.Data;
using CodingEvents.Models;
using CodingEvents.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodingEvents.Controllers
{
    public class EventsController : Controller
    {
        private readonly EventDbContext context;
        public EventsController(EventDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            List<Event> events = context.Events.Include(e => e.Category).ToList();
            return View(events);
        }

        [HttpGet]
        public IActionResult Add()
        {
            AddEventViewModel addEventViewModel = new AddEventViewModel(context.EventCategories.ToList());
            return View(addEventViewModel);
        }

        //[Bind("Name,Description,ContactEmail,Category,Location,NumberAttendees,MustRegister")]
        [HttpPost("/Events/Add")]
        public async Task<IActionResult> NewEvent(AddEventViewModel addEventViewModel)
        {
            if(ModelState.IsValid)
            {
                EventCategory category = context.EventCategories.Find(addEventViewModel.CategoryId);
                Event newEvent = new Event
                {
                    Name = addEventViewModel.Name,
                    Description = addEventViewModel.Description,
                    ContactEmail = addEventViewModel.ContactEmail,
                    Category = category,
                    Location = addEventViewModel.Location,
                    NumberAttendees = addEventViewModel.NumberAttendees,
                    MustRegister = addEventViewModel.MustRegister
                };

                context.Events.Add(newEvent);
                await context.SaveChangesAsync();

                return Redirect("/Events");
            }
            return View("Add", addEventViewModel);
        }

        public IActionResult Delete()
        {
            ViewBag.events = context.Events.ToList();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int[] eventIds)
        {
            foreach(int eventId in eventIds)
            {
                Event theEvent = await context.Events.FindAsync(eventId);
                context.Events.Remove(theEvent);
            }
            await context.SaveChangesAsync();
            return Redirect("/Events");
        }

        [HttpGet]
        [Route("/Events/Edit/{eventId}")]
        public IActionResult Edit(int eventId)
        {
            ViewBag.title = $"Edit Event {context.Events.Find(eventId).Name} (id={context.Events.Find(eventId).Id})";
            ViewBag.editEvent = context.Events.Find(eventId);

            //ViewBag.title = $"Edit Event {EventData.GetById(eventId).Name} (id={EventData.GetById(eventId).Id})";
            //ViewBag.editEvent = EventData.GetById(eventId);
            return View();
        }

        [HttpPost("/Events/Edit")]
        public IActionResult SubmittedEditEventForm(int eventId, string name, string description)
        {
            context.Events.Find(eventId).Name = name;
            context.Events.Find(eventId).Description = description;
            context.SaveChanges();
            return Redirect("/Events");
        }

        public IActionResult Detail(int id)
        {
            Event theEvent = context.Events
                .Include(e => e.Category)
                .Single(e => e.Id == id);

            List<EventTag> eventTags = context.EventTags
                .Where(et => et.EventId == id)
                .Include(et => et.Tag)
                .ToList();

            EventDetailViewModel eventDetailViewModel = new EventDetailViewModel(theEvent, eventTags);
            return View(eventDetailViewModel);
        }
    }
}
