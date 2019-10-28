using Association_Managment.DAL;
using Association_Managment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Association_Managment.BL
{
    public class JobMemberBL
    {
        public JobMemberDAL _jobMemberDAL { get; }
        public List<JobMember> Get(JobMemberCriteria criteria)
        {
            criteria = (criteria == null ? new JobMemberCriteria() : criteria);
            return _jobMemberDAL.Get(criteria);
        }

        public void AddJobMembers(JobMember jobMember, List<long> listCodes)
        {
         
            {
                _jobMemberDAL.AddJobMembers(jobMember,listCodes);
            }
        }
    }
}