using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Shared.Utilis
{
    public class UrlHelper
    {
        public string getParamsStr(string url)
        {
            return url.Split("?")[1];
        }
        public string[] getModulesStr(string param)
        {
            return param.Split("&");
        }
        public string[] getModule(string module)
        {
            return module.Split("=");
        }
        public string[] getRooms(string rooms)
        {
            return rooms.Split(",");
        }
        public string[] getClasseId(string myclass)
        {
            return myclass.Split(":");
        }

    }
}
