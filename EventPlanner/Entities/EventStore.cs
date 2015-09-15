using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner.Entities
{
    [Serializable]
    public class EventStore
    {
        public string User { get; set; }
        public List<Event> Data { get; set; }
    }
}
