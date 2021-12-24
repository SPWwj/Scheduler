using Newtonsoft.Json;
using System.Collections;

namespace Scheduler.Shared.Utilis
{
    class Semester
    {
        public static readonly int SemOne = 0;
        public static readonly int SemTwo = 1;
    }
    public class ModuleToSchedule
    {
        public List<AppointmentData> Data { get; set; } = new List<AppointmentData>();
        private UrlHelper urlHelper = new UrlHelper();

        string AcadYear = "2021-2022";

        string AcadStartDate = "Mon, 10 Jan 2022"; //Mon, 10 Jan 2022
        string myUrl = "https://nusmods.com/timetable/sem-2/share?CS1231S=TUT:05,LEC:1&CS2030S=REC:06,LAB:16B,LEC:1&CS2100=LAB:07,TUT:17,LEC:1&ES1103=SEC:A07&MA1521=LEC:1,TUT:6'";

        public async Task DecodeUrlAsync(string url)
        {
            var param = urlHelper.getParamsStr(url);
            var modStrArr = urlHelper.getModulesStr(param);
            foreach (string modStr in modStrArr)
            {
                var mod = urlHelper.getModule(modStr);
                //var mod = new string[] { "ES1103", "SEC:A07" };
                HttpClient client = new HttpClient();

                HttpResponseMessage response = await client.GetAsync($"https://api.nusmods.com/v2/{AcadYear}/modules/{mod[0]}.json");
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("My debug output.");
                    Console.WriteLine("My debug output.");

                    NUSMod nusMod = await response.Content.ReadAsAsync<NUSMod>();
                    pushModuleTimeTable(nusMod, mod[1]);

                }
            }

        }

        public void pushModuleTimeTable(NUSMod module, string roomsStr)
        {
            var myClassIds = this.urlHelper.getRooms(roomsStr).Select(myclass => this.urlHelper.getClasseId(myclass));
            var dateHelper = new DateHelper();

            var modClasses = module.semesterData[1].timetable.Where(table => myClassIds.Any(s => table.lessonType.Substring(0, 3).ToUpper() == s[0] && s[1] == table.classNo));

            foreach (var modClass in modClasses)
            {
                var myDeserializedClass = JsonConvert.DeserializeObject<List<int>>(modClass.weeks.ToString());
                Console.Write(myDeserializedClass);
                foreach (int week in myDeserializedClass)
                {
                    var d = new AppointmentData();
                    d.Subject = module.moduleCode;
                    d.StartTime = new DateTime(2022, 1, 10, Convert.ToInt32(modClass.startTime.Substring(0, 2)), Convert.ToInt32(modClass.startTime.Substring(2)), 0);
                    d.EndTime = new DateTime(2022, 1, 10, Convert.ToInt32(modClass.endTime.Substring(0, 2)), Convert.ToInt32(modClass.endTime.Substring(2)), 0);
                    d.StartTime = d.StartTime.AddDays(7 * (week - 1) + DateHelper.NumberOfDays(modClass.day));
                    d.EndTime = d.EndTime.AddDays(7 * (week - 1) + DateHelper.NumberOfDays(modClass.day));

                    d.Description = $"{ modClass.lessonType} : { modClass.classNo}, { modClass.venue}";
                    Data.Add(d);
                }

            }

        }
    }
}
