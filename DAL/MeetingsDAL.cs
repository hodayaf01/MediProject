using Association_Managment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Association_Managment.DAL
{
    public class MeetingsDAL
    {
        Association_ManagmentEntities DB = new Association_ManagmentEntities();
        public List<SelectProtocolsByCriteria_Result> GetMeetings(ProtocolsCriteria criteria)
        {
           
            var res = DB.SelectProtocolsByCriteria(criteria.MonthMeeting, criteria.DateMeeting, criteria.SubjectMeeting, criteria.MeetingDirector);
         
                return res.ToList();

        }
        public List<Meeting> Get(MeetingsCriteria criteria)
      {
           var res = DB.MeetingsSearch(criteria.codeMember,criteria.Subject,criteria.MeetingDate).ToList();
            List<Meeting> resu = res.Select(m => new Meeting()
            {
                CodeMeeting = m.CodeMeeting,
                CodeTypeMeeting = m.CodeTypeMeeting,
                DateCreated = m.DateCreated,
              MeetingDate = m.MeetingDate,
               MeetingDirector = m.MeetingDirector,
                SubjectMeeting = m.SubjectMeeting,
            //    NumOfMembers = m.NumOfMembers,
            //    TypeOfMeeting = m.TypeOfMeeting

            }).ToList();
           return resu;
        }
    }
}