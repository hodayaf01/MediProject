using Association_Managment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Association_Managment.DAL
{
    public class JobMemberDAL
    {
        Association_ManagmentEntities DB = new Association_ManagmentEntities();
        public List<JobMember> Get(JobMemberCriteria criteria)
        {
            var res = DB.JobMembersSearch(null/*criteria.CodeMember*/,criteria.CodeJob,criteria.DateStart,criteria.DateEnd).ToList();
            List<JobMember> resu = res.Select(s => new JobMember()
            {
                Code = s.Code,
                CodeMember=s.CodeMember,
                CodeJob=s.CodeJob,
                DateStart=s.DateStart,
                DateEnd=s.DateEnd,
                Note=s.Note,
                DateCreated=s.DateCreated,
                DeleteRow=s.DeleteRow,
            }).ToList();
            return resu;
        }

        internal void AddJobMembers(JobMember jobMember, List<long> listCodes)
        {
         
            foreach (long item in listCodes)
            {
                DB.JobMembers.Add(new JobMember() {
                    CodeJob =jobMember.CodeJob ,
                    CodeMember =item,
                    DateStart =jobMember.DateStart,
                    DateEnd =jobMember.DateEnd,
                    Note =jobMember.Note,
                    DateCreated =DateTime.Today,
                    DeleteRow =false});
            }


        }
    }
}