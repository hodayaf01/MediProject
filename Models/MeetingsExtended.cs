using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Association_Managment.Models
{
    public class MeetingsExtended: Meeting
    {
        public string TypeOfMeeting { get; set; }
        public int? NumOfMembers { get; set; }
    }
}