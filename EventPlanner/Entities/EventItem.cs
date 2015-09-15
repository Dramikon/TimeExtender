using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventPlanner.Entities
{
    [Serializable]
    public class EventItem
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Person ResponsiblePerson { get; set; }

        public List<Attachement> Attachements { get; set; }

        public List<Comment> Comments { get; set; }

        /// <summary>
        /// Items, which are dependant from this one. They cannot be proceed till this item is not closed
        /// </summary>
        public List<EventItem> DependantEventItems { get; set; }

        public EventItemState State { get; set; }
    }
}
