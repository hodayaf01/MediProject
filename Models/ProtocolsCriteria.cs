using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Association_Managment.Models
{
    public class ProtocolsCriteria
    {
        public DateTime DateMeeting { get; set; }
        public int MonthMeeting { get; set; }
        public string SubjectMeeting { get; set; }
        public string MeetingDirector { get; set; }

    }
}