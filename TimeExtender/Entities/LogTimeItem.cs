using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TimeExtender.Entities
{
    [Serializable]
    //[XmlType]
    public class LogTimeItem
    {
        [XmlIgnore]
        public Activity Activity { get; private set; }
        
        public string ActivityID { get; set; }

        [XmlIgnore]
        public TimeSpan LoggedTime 
        {
            get { return TimeSpan.FromMinutes(Minutes); }
            set { Minutes = value.TotalMinutes; } 
        }

        public double Minutes
        {
            get;
            set;
        }

        public DateTime DayOfLogging { get; set; }

        public LogTimeItem() { }
        public LogTimeItem(string activityId)
        {
            ActivityID = activityId;
        }
    }
}
