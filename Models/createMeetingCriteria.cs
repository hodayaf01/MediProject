using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Association_Managment.Models
{
    public class CreateMeetingCriteria
    {
        public int CodeMeeting { get; set; }
        public string SubjectMeeting { get; set; }
        public DateTime MeetingDate { get; set; }
        public int MeetingDirector { get; set; }
        public int CodeTypeMeeting { get; set; }
    }
}