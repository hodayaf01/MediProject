using Association_Managment.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Association_Managment.Controllers
{
    public class MeetingMemberController : ApiController
    {
        public MeetingMemberBL _meetingMemberBL { get;  }

        [Route("api/Job/AddOrEdit")]
        public void AddMembersToMeeting(List<long> codesMember,long codeMeeting)
        {
            _meetingMemberBL.AddMembersToMeeting(codesMember, codeMeeting);
        }



    }
}
