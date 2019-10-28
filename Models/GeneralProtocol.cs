using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Association_Managment.Models
{
    public class GeneralProtocol
    {
        public List<long> Presents { get; set; }
        public List<byte>  Tasks { get; set; }
        public int MeetingType { get; set; }
        public List<long> Signaturers { get; set; }
        public DateTime Date { get; set; }

        public List<Member> NewMember { get; set; }
        public QuitMember QuitMember { get; set; }
        public ChoosingAuditCommittee AuditCommitteeMembers { get; set; }
        public AppointmentOfAccountant Accountant { get; set; }
        public ConfirmReports confirmReports { get; set; }
        public UpdateAssociationDetail updateAssociationDetail { get; set; }
        public Other Other { get; set; }
    }
}