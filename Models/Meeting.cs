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
    
    public partial class Meeting
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Meeting()
        {
            this.MeetingMembers = new HashSet<MeetingMember>();
        }
    
        public long CodeMeeting { get; set; }
        public string SubjectMeeting { get; set; }
        public System.DateTime MeetingDate { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<bool> DeleteRow { get; set; }
        public string MeetingDirector { get; set; }
        public Nullable<long> CodeTypeMeeting { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MeetingMember> MeetingMembers { get; set; }
    }
}
