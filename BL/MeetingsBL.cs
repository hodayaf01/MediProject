using Association_Managment.DAL;
using Association_Managment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Association_Managment.BL
{
    public class MeetingsBL
    { 
        public MeetingsDAL _meetingsDAL { get; }

        public List<Meeting> Get(ProtocolsCriteria criteria)
        {
           
            var res = _meetingsDAL.GetMeetings(criteria);
            criteria = (criteria == null ? new ProtocolsCriteria() : criteria);
            List<Meeting> resu =res.Select(s => new Meeting()
            {
                CodeMeeting = s.CodeMeeting,
                MeetingDate=s.MeetingDate,
                SubjectMeeting=s.SubjectMeeting,
                DateCreated=s.DateCreated,
                MeetingDirector=s.MeetingDirector               
                
            }).ToList();
            return resu;
        }

        public List<Meeting> Get(MeetingsCriteria criteria)
        {
            criteria = (criteria == null ? new MeetingsCriteria() : criteria);
            return _meetingsDAL.Get(criteria);
        }
    }
}