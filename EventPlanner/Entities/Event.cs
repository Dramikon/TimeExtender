using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner.Entities
{
    [Serializable]
    public class Event
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Place { get; set; }

        public DateTime Date { get; set; }

        public Person ResponsiblePerson { get; set; }

        public List<Person> ExternalEmployees { get; set; }

        public List<EventItem> Items { get; set; }
    }
}
