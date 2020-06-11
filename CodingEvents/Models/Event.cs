using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public override string ToString()
        {
            return Name;
        }


    }
}
