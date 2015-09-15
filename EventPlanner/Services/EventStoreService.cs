using EventPlanner.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace EventPlanner.Services
{
    public class EventStoreService
    {
        private const string FILE_NAME = "EventStore.xml";
        private static EventStore Cache;
        private static object SyncRoot = new object();

        public static string GetOwner()
        {
            CheckCache();
            return Cache.User;
        }

        public static void SetOwner(string user)
        {
            CheckCache();
            Cache.User = user;
        }

        public static List<LogTimeItem> GetItemsByDate(DateTime date)
        {
            CheckCache();
            return Cache.Data.FindAll(x => x.DayOfLogging.Date == date.Date);
        }

        public static List<LogTimeItem> GetItemsByDateRange(DateTime start, DateTime end)
        {
            CheckCache();
            return Cache.Data.FindAll(x => x.DayOfLogging.Date >= start.Date && x.DayOfLogging.Date <= end.Date);
        }

        public static void AddLogItem(LogTimeItem item)
        {
            CheckCache();
            Cache.Data.Add(item);
        }

        public static List<Activity> GetActivities()
        {
            CheckCache();
            return Cache.Activities;
        }

        public static void AddActivity(Activity activity)
        {
            CheckCache();
            Cache.Activities.Add(activity);
        }

        public static void RemoveActivity(Activity activity)
        {
            CheckCache();
            Cache.Activities.Remove(activity);
        }

        public static void RemoveActivityByName(string name)
        {
            CheckCache();
            Cache.Activities.RemoveAll(a => a.Name == name);
        }

        private static void CheckCache()
        {
            if (Cache == null)
            {
                lock (SyncRoot)
                {
                    if (Cache == null)
                    {
                        if (File.Exists(FILE_NAME))
                        {
                            using (var stream = new FileStream(FILE_NAME, FileMode.Open, FileAccess.Read, FileShare.Read))
                            {
                                System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(LogItemStore));
                                {
                                    Cache = (LogItemStore)ser.Deserialize(stream);
                                }
                            }
                        }
                        else
                        {
                            Cache = new LogItemStore();
                            Cache.Data = new List<LogTimeItem>();
                            Cache.Activities = new List<Activity>();
                        }
                    }
                }
            }
        }

        public static void Remove(LogTimeItem item)
        {
            if (Cache != null)
            { 
                lock(SyncRoot)
                {
                    Cache.Data.Remove(item);
                }
            }
        }

        public static void Save()
        {
            Save(Cache);
        }

        public static void Save(LogItemStore store)
        {
            using (var stream = new FileStream(FILE_NAME, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                using (var writer = XmlWriter.Create(stream))
                {
                    System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(LogItemStore));
                    {
                        ser.Serialize(writer, store);
                    }
                }
            }
        }
    }
}
