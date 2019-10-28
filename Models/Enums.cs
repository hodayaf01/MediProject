using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Association_Managment.Models
{
    public class Enums
    {
        public enum Task
        {
             AddMember = 1,
             QuitMember,
             ChoosingAuditCommittee,
             AppointmentOfAccountant,
             ConfirmReports,
             UpdateAssociationDetail,
             Other
        };
        public enum Jobs
        {
            Manager=1,//מנהל
            AuditCommitteeMember,//ןעדת ביקורת 
            Accountant,//רואה חשבון
            Other//אחר
        };
    }
}