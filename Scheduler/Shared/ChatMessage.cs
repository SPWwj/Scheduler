using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Shared
{
    public class ChatMessage
    {
        public Guid SenderId { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
