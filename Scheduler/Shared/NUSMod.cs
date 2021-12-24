using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Shared
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Attributes
    {
        public bool su { get; set; }
    }

    public class Timetable
    {
        public string classNo { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
        public object weeks { get; set; }
        public string venue { get; set; }
        public string day { get; set; }
        public string lessonType { get; set; }
        public int size { get; set; }
        public string covidZone { get; set; }
    }

    public class SemesterData
    {
        public int semester { get; set; }
        public List<Timetable> timetable { get; set; }
        public List<string> covidZones { get; set; }
        public DateTime? examDate { get; set; }
        public int? examDuration { get; set; }
    }

    public class NUSMod
    {
        public string acadYear { get; set; }
        public string preclusion { get; set; }
        public string description { get; set; }
        public string title { get; set; }
        public string department { get; set; }
        public string faculty { get; set; }
        public List<int> workload { get; set; }
        public string prerequisite { get; set; }
        public string moduleCredit { get; set; }
        public string moduleCode { get; set; }
        public Attributes attributes { get; set; }
        public List<SemesterData> semesterData { get; set; }
        public List<string> fulfillRequirements { get; set; }
    }



}
