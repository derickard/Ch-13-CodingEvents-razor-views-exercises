using System;
using System.Collections.Generic;
using System.Linq;
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

        public Event(string name, string description) 
        {
            Name = name;
            Description = description;
            Id = nextId;
            nextId++;
        }

        public Event()
        {
            Id = nextId;
            nextId++;
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
