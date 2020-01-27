using System;
using System.Collections.Generic;
using System.Text;

namespace CashdeskManager.Models
{
    public class CameraEvent
    {
        public int EventId { get; set; }
        public string EventName { get; set; } // Entry or Exit
        public int CameraId { get; set; }
        public DateTime? Timestamp { get; set; }
    }
}
