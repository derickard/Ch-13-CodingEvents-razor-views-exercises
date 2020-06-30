using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using CodingEvents.Data;
using CodingEvents.Models;
using CodingEvents.ViewModels;

namespace CodingEvents.Controllers
{
    public class EventCategoryController : Controller
    {
        private readonly EventDbContext context;
        public EventCategoryController(EventDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<EventCategory> categories = context.EventCategories.ToList();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            AddEventCategoryViewModel addEventCategoryViewModel = new AddEventCategoryViewModel();
            return View(addEventCategoryViewModel);
        }

        [HttpPost("/EventCategory/Create")]
        public async Task<IActionResult> ProcessCreateEventCategoryForm([Bind("Name")] AddEventCategoryViewModel addEventCategoryViewModel)
        {
            if(ModelState.IsValid)
            {
                EventCategory newCategory = new EventCategory(addEventCategoryViewModel.Name);
                context.EventCategories.Add(newCategory);
                await context.SaveChangesAsync();

                return Redirect("/EventCategory");

            }

            return View("Create", addEventCategoryViewModel);
        }
    }
}
