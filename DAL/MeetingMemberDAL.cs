using Association_Managment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Association_Managment.DAL
{
    public class MeetingMemberDAL
    {
        Association_ManagmentEntities DB = new Association_ManagmentEntities();
        public void AddMembersToMeeting(List<long> codesMember, long codeMeeting)
        {
            foreach (long item in codesMember)
            {
                DB.MeetingMembers.Add(new MeetingMember() { CodeMeeting = codeMeeting, CodeMember = item });
            }
        }
    }
}
