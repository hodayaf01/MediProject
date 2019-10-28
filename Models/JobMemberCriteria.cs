using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Association_Managment.Models
{
    public class JobMemberCriteria
    {
        public long? CodeMember { get; set; }
        public string NameJob { get; set; }
        public long? CodeJob { get; set; }
        public Nullable<System.DateTime> DateStart { get; set; }
        public Nullable<System.DateTime> DateEnd { get; set; }
    }
}