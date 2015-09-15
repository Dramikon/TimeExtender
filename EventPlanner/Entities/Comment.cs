using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventPlanner.Entities
{
    [Serializable]
    public class Comment
    {
        public Person Author { get; set; }

        public DateTime Date { get; set; }

        public string Text { get; set; }
    }
}
