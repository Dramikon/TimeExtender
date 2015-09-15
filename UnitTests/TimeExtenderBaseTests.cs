using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeExtender.Service;
using TimeExtender.Entities;

namespace UnitTests
{
    [TestClass]
    public class BasicTests
    {
        [TestMethod]
        public void XmlTests()
        {
            LogItemStore store = new LogItemStore();
            store.User = "Kseniya_Kononova@epam.com";
            store.Data = new System.Collections.Generic.List<LogTimeItem>() 
            {
                new LogTimeItem(){ ActivityID = "Task1", DayOfLogging = DateTime.Now.Date, LoggedTime = TimeSpan.FromHours(19) },
                new LogTimeItem(){ ActivityID = "Task2", DayOfLogging = DateTime.Now.Date, LoggedTime = TimeSpan.FromHours(20) },
                new LogTimeItem(){ ActivityID = "Task3", DayOfLogging = DateTime.Now.Date.AddDays(-1), LoggedTime = TimeSpan.FromHours(1) },
            };

            store.Activities = new System.Collections.Generic.List<Activity>() 
            {
                new Activity(){ ID = "Task1", Name = "EPAM Creation" },
                new Activity(){ ID = "Task2", Name = "Customer Interview" }
            };

            LogItemsService.Save(store);

            var result = LogItemsService.GetItemsByDate(DateTime.Now.Date);
        }

        [TestMethod]
        public void ExportTest() 
        {
            //ExcelExporter.ExportReport(LogItemsService.GetItemsByDate(DateTime.Now.Date), "testReport.xlsx");
        }
    }
}
