using Association_Managment.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Association_Managment.BL
{
    public class MeetingMemberBL
    {
        public MeetingMemberDAL _meetingMemberDAL { get;  }
        

        public void AddMembersToMeeting(List<long> codesMember, long codeMeeting)
        {
            _meetingMemberDAL.AddMembersToMeeting(codesMember, codeMeeting);
        }
    }
}