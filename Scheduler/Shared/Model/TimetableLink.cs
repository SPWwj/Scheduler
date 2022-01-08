using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Shared
{
    public class TimetableLink
    {
        public Guid Id { get; set; }
        public bool Loaded { get; set; }
        public string Url { get; set; }
        public Guid OwerID { get; set; }
        public string Name { get; set; }

    }
}
