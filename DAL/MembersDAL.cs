using Association_Managment.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Association_Managment.DAL
{
    public class MembersDAL
    {
        Association_ManagmentEntities DB = new Association_ManagmentEntities();
        public List<Member> Get(MembersCriteria criteria)
        {
            var res= DB.MembersSearch(criteria.NameMember, criteria.IdMember, criteria.TypeMember, criteria.AllowedSignature, criteria.MailMember, criteria.Joindate, criteria.Exitdate).ToList();
            List<Member> resu = res.Select(s => new Member() {
                codeMember=s.codeMember,
                NameMember=s.NameMember,
                IdMember=s.IdMember,
                ExitDate=s.ExitDate,
                MailMember=s.MailMember,
                JoinDate=s.JoinDate,
                TypeMember=s.TypeMember,
                AllowedSignature = s.AllowedSignature
            }).ToList();
            return resu ;
        }
        public void AddOrEditMember(Member newMember)
        {
            DB.Members.AddOrUpdate(newMember);
        }

    }
}