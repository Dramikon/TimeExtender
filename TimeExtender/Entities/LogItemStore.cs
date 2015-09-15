using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeExtender.Entities
{
    [Serializable]
    public class LogItemStore
    {
        public string User { get; set; }
        public List<LogTimeItem> Data { get; set; }
        public List<Activity> Activities { get; set; }
    }
}
