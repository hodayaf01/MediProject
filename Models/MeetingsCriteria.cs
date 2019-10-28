using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Association_Managment.Models
{
    public class MeetingsCriteria
    {
        public int? codeMember { get; set; }
        public string Subject { get; set; }
        public DateTime? MeetingDate { get; set; }
    }
}