using Association_Managment.BL;
using Association_Managment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
namespace Association_Managment.Controllers
{
    public class MeetingsController : ApiController
    {
        public BL.MeetingsBL _meetingBL = new MeetingsBL();
        [Route("api/Meeting/Get")]
        [HttpGet]
        public List<Meeting> Get(ProtocolsCriteria criteria)
        {
            return _meetingBL.Get(criteria);
        }

        public GeneralBL _GeneralBL = new GeneralBL();
        [Route("api/Meeting/Invite")]
        [HttpGet]

        public bool Invite(string sub,[FromUri]List<string> membersInvite,string director,DateTime date)
        {
            string body = "you are invited for meeting by " + director + " on " + date+" about "+sub;
            SendEmailModel sem=new SendEmailModel(null,sub,body, membersInvite);
            return _GeneralBL.CreateMail(sem);
        }

        [HttpGet]
        [Route("api/Meeting/GetByCriteria")]
        public List<Meeting> Get(int? codeMember = null, string subject = null, DateTime? MeetingDate = null)
        {
            MeetingsCriteria criteria = new MeetingsCriteria() { codeMember = codeMember, MeetingDate = MeetingDate, Subject = subject };

            return _meetingBL.Get(criteria);
        }
    }
}
