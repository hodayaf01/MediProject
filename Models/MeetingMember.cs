//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Association_Managment.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MeetingMember
    {
        public long CodeMeeting { get; set; }
        public long CodeMember { get; set; }
        public long Code { get; set; }
    
        public virtual Meeting Meeting { get; set; }
        public virtual Member Member { get; set; }
    }
}
