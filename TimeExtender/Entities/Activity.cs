using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeExtender.Entities
{
    [Serializable]
    public class Activity
    {
        public string ID
        {
            get;
            set;
        }

        public string Name { get; set; }

        public string Description { get; set; }

        /// <summary>
        /// Comma separated list
        /// </summary>
        public string PeopleInvolved { get; set; }
    }
}
