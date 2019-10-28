using Association_Managment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Association_Managment.BL
{
    public partial class MembersBL
    {
        public List<Member> Get(List<long> l)
        {
            List<Member> members = new List<Member>();
            foreach (long item in l)
            {
                members.Add(_membersDAL.Get(new MembersCriteria()).ToList().Find(i => i.codeMember == item));
            }
            return members;
        }
        public Member Get(long code)
        {
            Member members = new Member(); //new Members(_membersDAL.Get(new MembersCriteria()).ToList().Find(i => i.codeMember == code));                                   
            return members;
        }
    }
}