using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner.Entities
{
    [Serializable]
    public class Person
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Skype { get; set; }

        public string Phone { get; set; }

        public string Company { get; set; }

        public List<string> AdditionalInfo { get; set; }
    }
}
