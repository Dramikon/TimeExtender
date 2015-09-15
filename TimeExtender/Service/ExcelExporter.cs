using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OfficeOpenXml;
using TimeExtender.Entities;
using System.IO;

namespace TimeExtender.Service
{
    public class ExcelExporter
    {
        private const string TIME_SPAN_FORMAT = "[h]:mm";
        private const string DATE_FORMAT = "\n dd-MM-yyyy";

        public static void ExportReport(List<LogTimeItem> itemsToExport, string fileName, 
            string owner, DateTime startOfWeek, bool overWrite = true)
        {
            FileInfo file = new FileInfo(fileName);
            if (overWrite && file.Exists)
            {
                file.Delete();
            }
            using(ExcelPackage pack = new ExcelPackage(file))
            {
                var reportSheet = pack.Workbook.Worksheets.Add("Week Report");

                //reportSheet.InsertRow(0, 100);

                reportSheet.Cells[1, 1].Value = "Task";

                SetDay(DayOfWeek.Monday, startOfWeek, reportSheet);
                SetDay(DayOfWeek.Tuesday, startOfWeek, reportSheet);
                SetDay(DayOfWeek.Wednesday, startOfWeek, reportSheet);
                SetDay(DayOfWeek.Thursday, startOfWeek, reportSheet);
                SetDay(DayOfWeek.Friday, startOfWeek, reportSheet);
                SetDay(DayOfWeek.Saturday, startOfWeek, reportSheet);
                SetDay(DayOfWeek.Sunday, startOfWeek, reportSheet);
                
                var lastColumn = GetDayNumber(DayOfWeek.Sunday) + 2;
                reportSheet.Cells[1, lastColumn].Value = "Week Total";

                Dictionary<string, int> activitiesToCells = new Dictionary<string, int>();
                int activitiesCounter = 0;
                for (int i = 0; i < itemsToExport.Count; i++)
                {
                    var item = itemsToExport[i];

                    int currentRow;
                    if (!activitiesToCells.TryGetValue(item.ActivityID, out currentRow))
                    {
                        //meet this activity first time on this sheet
                        currentRow = activitiesCounter;
                        activitiesToCells.Add(item.ActivityID, activitiesCounter++);
                    }

                    //add a row with activity name
                    var actCell = reportSheet.Cells[currentRow + 2, 1];
                    actCell.Value = item.ActivityID;
                    actCell.AutoFitColumns(50);

                    var cell = reportSheet.Cells[currentRow + 2, GetDayNumber(item.DayOfLogging.DayOfWeek) + 1];
                    //cell.Value = item.LoggedTime.ToString();
                    cell.Value = item.LoggedTime;
                    cell.Style.Numberformat.Format = TIME_SPAN_FORMAT;

                    //cell.Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                }

                int lastRow = activitiesCounter + 2;
                //from second column for all week days
                for (int i = 2; i <= 8; i++)
                {
                    var cell = reportSheet.Cells[lastRow, i];
                    //cell.Value = item.LoggedTime.ToString();
                    cell.Formula = string.Format("SUM({0}:{1})", reportSheet.Cells[2, i].Address, reportSheet.Cells[lastRow - 1, i].Address);  
                    cell.Style.Numberformat.Format = TIME_SPAN_FORMAT;

                    //cell.Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thick);
                }

                //go through the all cells and set the style
                for (int i = 1; i <= lastRow; i++)
                {
                    if (i > 1)
                    { 
                        //setup total week sum for activities
                        var cell = reportSheet.Cells[i, lastColumn];
                        cell.Formula = string.Format("SUM({0}:{1})", reportSheet.Cells[i, 2].Address, reportSheet.Cells[i, lastColumn - 1].Address);
                        cell.Style.Numberformat.Format = TIME_SPAN_FORMAT;
                    }
                    for (int j = 1; j <= lastColumn; j++)
                    {
                        reportSheet.Cells[i, j].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    }
                }

                reportSheet.Cells[lastRow + 2, 1].Value = owner;
                
                pack.Save();
            }

            
        }

        private static void SetDay(DayOfWeek day, DateTime startOfWeek, ExcelWorksheet reportSheet)
        {
            var cell = reportSheet.Cells[1, GetDayNumber(day) + 1];
            cell.Value = day.ToString() + startOfWeek.AddDays(GetDayNumber(day) - 1).Date.ToString(DATE_FORMAT);
            cell.Style.WrapText = true;
            cell.AutoFitColumns(12);
        }

        /// <summary>
        /// Return numbder of week day starting from 1. Sunday is day 7.
        /// </summary>
        private static int GetDayNumber(DayOfWeek day)
        {
            const int SUNDAY_NUMBER = 7;
            if (day == DayOfWeek.Sunday)
            {
                return SUNDAY_NUMBER;
            }
            return (int)day;
        }

    }
}
