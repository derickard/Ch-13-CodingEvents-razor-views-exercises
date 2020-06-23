using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace CodingEvents.Models
{
    public class Event
    {
        public int Id { get; }
        static private int nextId = 1;
        public string Name { get; set; }
        public string Description { get; set; }
        public string ContactEmail { get; set; }
        public string Location { get; set; }
        public int NumberAttendees { get; set; }
        public bool MustRegister { get; set; }
        public EventType Type { get; set; }


        public Event()
        {
            Id = nextId;
            nextId++;
        }

        public Event(string name, string description, string email, EventType type, string location, int attendees, bool register) : this()
        {
            Name = name;
            Description = description;
            ContactEmail = email;
            Location = location;
            NumberAttendees = attendees;
            MustRegister = register;
            Type = type;

        }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            return obj is Event @event &&
                   Id == @event.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
