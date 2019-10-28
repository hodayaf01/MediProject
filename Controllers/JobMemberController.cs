using Association_Managment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Association_Managment.Controllers
{
    public class JobMemberController : ApiController
    {
        public BL.JobMemberBL _jobMemberBL { get; }
        [Route("api/JobMember/Get")]
        [HttpGet]
        public List<JobMember> Get(JobMemberCriteria criteria)
        {
            return _jobMemberBL.Get(criteria);
        }

        [HttpPost]
        public void AddJobMembers(JobMember jobMember, List<long> listCodes)
        {
             _jobMemberBL.AddJobMembers(jobMember,listCodes);

        }


    }
}
